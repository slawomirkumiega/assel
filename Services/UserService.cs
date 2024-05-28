using Assel.DTO;
using Assel.Repositories;
using AutoMapper;

namespace Assel.Services
{
    internal sealed class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UserService(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<IReadOnlyList<UserDto>> GetAll()
        {
            var users = await _userRepository.GetAll();
            return users.Select(_mapper.Map<UserDto>).ToList();
        }
    }
}
