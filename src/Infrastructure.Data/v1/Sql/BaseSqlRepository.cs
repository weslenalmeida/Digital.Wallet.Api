using CrossCutting.Configuration;
using Npgsql;
using System.Data;

namespace Infrastructure.Data.v1.Sql
{
    abstract public class BaseSqlRepository
    {
        protected IDbConnection CreateConnection()
            => new NpgsqlConnection(AppSettings.ConnectionSettings.ConnectionSqlString);
    }
}
