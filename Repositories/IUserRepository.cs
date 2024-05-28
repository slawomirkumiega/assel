using Assel.Entities;

namespace Assel.Repositories
{
    internal interface IUserRepository
    {
        Task<IEnumerable<User>> GetAll();
        Task<IEnumerable<User>> FindByIds(IEnumerable<string> ids);

        Task Add(User user);
        void Update(User user);
    }
}
