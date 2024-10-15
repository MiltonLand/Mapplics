using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using Dapper;
using MapplicsEjercicio2.Domain.Interfaces;

namespace MapplicsEjercicio2.Infrastructure
{
    public class DapperDataAccess : IDapperDataAccess
    {
        private readonly IConfiguration _config;

        public DapperDataAccess(IConfiguration config)
        {
            _config = config;
        }

        public async Task<IEnumerable<T>> LoadData<T, U>(string storedProcedure, U parameters, string connectionId = "Default")
        {
            using IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionId));

            return await connection.QueryAsync<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
