using Domain.Entities.v1;

namespace Domain.Interfaces.v1.Repositories
{
    public interface ITransferRepository
    {
        public Task CreateTransferAsync(MoneyTransferEntity moneyTransfer);
        public Task<IEnumerable<MoneyTransferEntity>> GetTransfersByUserAsync(Guid id);
        public Task<IEnumerable<MoneyTransferEntity>> GetTransfersByDatesAsync(Guid id, DateTime? start, DateTime? end);
        public Task<IEnumerable<MoneyTransferEntity>> GetTransfersByDateAsync(Guid id, DateTime? date);
    }
}
