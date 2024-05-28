using Assel.DTO;
using Assel.Entities;

namespace Assel.Repositories
{
    internal interface IFactRepository
    {
        Task<IEnumerable<Fact>> GetAll();
    }
}
