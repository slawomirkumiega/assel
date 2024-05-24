using users.DTO;

namespace users.Services
{
    public interface IUserService
    {
        Task<IReadOnlyList<UserDto>> GetAll();
        Task Add(UserDto userDto);
        Task Delete(int id);
    }
}
