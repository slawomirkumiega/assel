using Assel.DTO;
using Assel.Repositories;
using AutoMapper;

namespace Assel.Services
{
    internal sealed class FactService : IFactService
    {
        private readonly IMapper _mapper;
        private readonly IFactRepository _factRepository;

        public FactService(IMapper mapper, IFactRepository factRepository)
        {
            _mapper = mapper;
            _factRepository = factRepository;
        }

        public async Task<IReadOnlyList<FactDto>> GetAll()
        {
            var facts = await _factRepository.GetAll();
            return facts.Select(_mapper.Map<FactDto>).ToList();
        }
    }
}
