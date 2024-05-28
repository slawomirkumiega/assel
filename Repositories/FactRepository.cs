using Assel.Data;
using Assel.Entities;
using Dapper;

namespace Assel.Repositories
{
    internal sealed class FactRepository : IFactRepository
    {
        private readonly DapperContext _context;

        public FactRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Fact>> GetAll()
        {
            var query = "SELECT * FROM Facts";

            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<Fact>(query);
        }
    }
}
