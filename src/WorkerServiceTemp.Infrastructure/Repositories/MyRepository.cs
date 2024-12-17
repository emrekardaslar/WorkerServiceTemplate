using Dapper;
using Microsoft.Data.SqlClient;
using WorkerServiceTemp.Core.Entities;

namespace WorkerServiceTemp.Infrastructure.Repositories
{
    public class MyRepository
    {
        private readonly string _connectionString;

        public MyRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<MyEntity>> GetAllAsync()
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryAsync<MyEntity>("SELECT * FROM MyEntities");
        }
    }
}
