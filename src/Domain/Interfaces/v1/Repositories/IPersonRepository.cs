using Domain.Entities.v1;

namespace Domain.Interfaces.v1.Repositories
{
    public interface IPersonRepository
    {
        public Task<PersonEntity> GetUserAsync(string email, string password);
    }
}