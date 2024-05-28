using Assel.DTO;

namespace Assel.Services
{
    public interface IFactService
    {
        Task<IReadOnlyList<FactDto>> GetAll();
    }
}
