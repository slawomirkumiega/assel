using Assel.ApiDto;
using Assel.Data;
using Assel.Entities;
using Assel.Repositories;
using AutoMapper;

namespace Assel.Services
{
    internal class ImportFact : IImportFact
    {
        private readonly AsselDbContext _dbContext;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<ImportFact> _logger;
        private readonly HttpClient _httpClient;

        private readonly string ServiceUrl;
        public ImportFact(IConfiguration config, IHttpClientFactory factory,
            AsselDbContext dbContext, IUserRepository userRepository, IMapper mapper, ILogger<ImportFact> logger)
        {
            _dbContext = dbContext;
            _userRepository = userRepository;

            ServiceUrl = config.GetValue<string>("Services:Fact") 
                ?? throw new ArgumentNullException(nameof(config));

            _mapper = mapper;
            _logger = logger;
            _httpClient = factory.CreateClient();
        }

        public async Task ImportUniqueDataAsync()
        {
            try
            {
                var apiResult = await _httpClient.GetFromJsonAsync<IReadOnlyList<FactApiDto>>(ServiceUrl);

                if (apiResult == null)
                {
                    _logger.LogInformation("No data to import");
                    return;
                }

                var users = await _userRepository.FindByIds(GetUniqueUserIds(apiResult));

                foreach (var row in GroupData(apiResult))
                {
                    var user = users.FirstOrDefault(x => x.Id == row.Key);
                    if (user is null)
                    {
                        await TryAddFactForNewUser(row);
                        continue;
                    }
                    
                    TryAddNewFacts(row, user);
                    
                }
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected issue during importing data");
            }
        }

        private async Task TryAddFactForNewUser(IGrouping<string, FactApiDto> row)
        {
            var userEntity = new User(row.Key);

            if (row.Any())
            {
                userEntity.AddFacts(_mapper.Map<IEnumerable<Fact>>(row));
            }
            await _userRepository.Add(userEntity);
        }

        private void TryAddNewFacts(IGrouping<string, FactApiDto> row, User user)
        {
            var facts = row.Where(x => !user.Facts.Select(x => x.Id).Contains(x._Id)).ToList();
            if (facts.Any())
            {
                user.AddFacts(_mapper.Map<IEnumerable<Fact>>(facts));
                _userRepository.Update(user);
            }
        }

        private static IEnumerable<IGrouping<string, FactApiDto>> GroupData(IReadOnlyList<FactApiDto> apiResult)
        {
            return apiResult.GroupBy(x => x.User);
        }

        private static IEnumerable<string> GetUniqueUserIds(IReadOnlyList<FactApiDto> apiResult)
        {
            return apiResult.Select(x => x.User).Distinct();
        }
    }
}
