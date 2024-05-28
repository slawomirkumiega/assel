using Microsoft.Data.Sqlite;
using System.Data;

namespace Assel.Data
{
    internal class DapperContext
    {
        protected readonly IConfiguration Configuration;

        public DapperContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IDbConnection CreateConnection()
        {
            return new SqliteConnection(Configuration.GetConnectionString("AsselStore"));
        }
    }
}
