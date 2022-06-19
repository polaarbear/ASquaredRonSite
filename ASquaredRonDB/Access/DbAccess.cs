using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ASquaredRonDB.Access
{
    public class DbAccess : IDbAccess
    {
        public IConfiguration _config { get; set; }

        public DbAccess(IConfiguration config)
        {
            _config = config;
        }

        public async Task<List<T>> LoadData<T, U>(string sqlText, U parameters, string connectionStringName)
        {
            string connectionString = _config.GetConnectionString(connectionStringName);
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                var rows = await connection.QueryAsync<T>(sqlText, parameters, commandType: CommandType.Text);
                return rows.ToList();
            }
        }

        public async Task<int> SaveData<T>(string sqlText, T parameters, string connectionStringName)
        {
            string connectionString = _config.GetConnectionString(connectionStringName);
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                var newRow = await connection.ExecuteScalarAsync<int>(sqlText, parameters, commandType: CommandType.Text);
                return newRow;
            }
        }
    }
}
