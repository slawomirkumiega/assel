using Assel.DTO;

namespace Assel.Services
{
    public interface IUserService
    {
        Task<IReadOnlyList<UserDto>> GetAll();
    }
}
