using Dapper;
using Domain.Entities.v1;
using Domain.Interfaces.v1.Repositories;
using Infrastructure.Data.v1.Sql;
using System.Data;

namespace Infrastructure.Data.v1.Mongo
{
    public class PersonRepository : BaseSqlRepository, IPersonRepository
    {
        private IDbConnection _connection;

        public PersonRepository()
        {
            _connection = CreateConnection();
        }

        public async Task CreateUserAsync(PersonEntity personEntity)
        {
            var sql = @"
            INSERT INTO persons (id, name, document, birth_date, email, password, activated, role, registration_date, account_balance)
            VALUES (@ Id, @Name, @Document, @BirthDate, @Email, @Password, @Activated, @Role, @RegistrationDate, @AccountBalance);
            ";

            await _connection.ExecuteAsync(sql, personEntity);
        }

        public async Task<decimal?> GetAccountBalanceAsync(Guid id)
        {
            var sql = @"
            SELECT account_balance
            FROM persons
            WHERE id = @Id;
            ";

            using var connection = CreateConnection();
            return await connection.ExecuteScalarAsync<decimal?>(sql, new { Id = id });
        }

        public async Task<PersonEntity> GetUserAsync(string email, string password)
        {
            var sql = @"
            SELECT id, name, document, birth_date AS BirthDate, email, password, activated, role, registration_date AS RegistrationDate, account_balance AS AccountBalance
            FROM persons
            WHERE email = @Email AND password = @Password;
            ";

            return await _connection.QueryFirstOrDefaultAsync<PersonEntity>(sql, new { Email = email, Password = password });
        }

        public async Task<bool> UpdateAccountBalanceAsync(Guid userId, decimal? newBalance)
        {
            var sql = @"
            UPDATE persons
            SET account_balance = @AccountBalance
            WHERE document = @Document;
            ";

            using var connection = CreateConnection();
            var affected = await connection.ExecuteAsync(sql, new { Id = userId, AccountBalance = newBalance });
            return affected > 0;
        }
    }
}