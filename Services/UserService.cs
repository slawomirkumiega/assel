using AutoMapper;
using Microsoft.EntityFrameworkCore;
using users.Data;
using users.DTO;
using users.Entities;
using users.Exceptions;

namespace users.Services
{
    internal sealed class UserService : IUserService
    {
        private readonly UsersDbContext _db;
        private readonly IMapper _mapper;
        private readonly ILogger<UserService> _logger;

        public UserService(UsersDbContext db, IMapper mapper, ILogger<UserService> logger)
        {
            _db = db;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task Add(UserDto userDto)
        {
            await ValidateUser(userDto);

            var user = new User(userDto.Id, userDto.FirstName, userDto.Surname, userDto.Login);
            await _db.Users.AddAsync(user);
            await _db.SaveChangesAsync();
            _logger.LogInformation($"User with id: '{userDto.Id}' has been created successfully.");
        }

        public async Task Delete(int id)
        {
            var user = await _db.Users.SingleOrDefaultAsync(x => x.Id == id);

            if (user is null)
            {
                throw new UserNotFoundException(id);
            }

            _db.Set<User>().Remove(user);
            await _db.SaveChangesAsync();
            _logger.LogInformation($"The user with id: '{user.Id}' and login: '{user.Login}' has been deleted.");
        }

        public async Task<IReadOnlyList<UserDto>> GetAll()
        {
            var users = await _db.Users.ToListAsync();

            return users.Select(_mapper.Map<UserDto>).ToList();
        }

        private async Task ValidateUser(UserDto userDto)
        {
            if (await _db.Users.AnyAsync(x => x.Id == userDto.Id))
            {
                throw new UserAlreadyExistsException(userDto.Id);
            }

            if (string.IsNullOrWhiteSpace(userDto.FirstName))
            {
                throw new InvalidFirstNameException(userDto.FirstName);
            }

            if (string.IsNullOrWhiteSpace(userDto.Surname))
            {
                throw new InvalidSurnameException(userDto.Surname);
            }

            if (string.IsNullOrWhiteSpace(userDto.Login))
            {
                throw new InvalidLoginException(userDto.Login);
            }
        }
    }
}
