using Domain.Entities.v1;
using Domain.Interfaces.v1.Repositories;

namespace Infrastructure.Data.v1.Mongo
{
    public class PersonRepository : IPersonRepository
    {
        public Task<PersonEntity> GetUserAsync(string email, string password)
        {
            throw new NotImplementedException();
        }
    }
}