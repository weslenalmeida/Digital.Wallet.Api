using Domain.Entities.v1;

namespace Domain.Interfaces.v1.Repositories
{
    public interface IPersonRepository
    {
        public Task<PersonEntity> GetUserAsync(string email, string password);
        public Task CreateUserAsync(PersonEntity personEntity);
        public Task<decimal?> GetAccountBalanceAsync(Guid id);
        public Task<bool> UpdateAccountBalanceAsync(Guid userId, decimal? newBalance);
    }
}