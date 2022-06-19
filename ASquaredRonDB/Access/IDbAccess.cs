using Microsoft.Extensions.Configuration;

namespace ASquaredRonDB.Access
{
    public interface IDbAccess
    {
        IConfiguration _config { get; set; }

        Task<List<T>> LoadData<T, U>(string sqlText, U parameters, string connectionStringName);
        Task<int> SaveData<T>(string sqlText, T parameters, string connectionStringName);
    }
}