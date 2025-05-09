using Dapper;
using Domain.Entities.v1;
using Domain.Interfaces.v1.Repositories;
using System.Data;

namespace Infrastructure.Data.v1.Sql
{
    public class TransferRepository : BaseSqlRepository, ITransferRepository
    {
        private IDbConnection _connection;

        public TransferRepository()
        {
            _connection = CreateConnection();
        }
        public async Task CreateTransferAsync(MoneyTransferEntity moneyTransfer)
        {
            var sql = @"
            INSERT INTO money_transfers (id, origin_person_id, destination_person_id, transfer_amount, transfer_date)
            VALUES (@Id, @OriginPersonId, @DestinationPersonId, @TransferAmount, @TransferDate);
            ";
            await _connection.ExecuteAsync(sql, moneyTransfer);
        }

        public async Task<IEnumerable<MoneyTransferEntity>> GetTransfersByDateAsync(Guid id, DateTime? date)
        {
            var sql = @"
            SELECT id, origin_person_id AS OriginPersonId, destination_person_id AS DestinationPersonId, 
            transfer_amount AS TransferAmount, transfer_date AS TransferDate
            FROM money_transfers
            WHERE origin_person_id = @OriginPersonId
            AND DATE(transfer_date) = DATE(@TransferDate);
            ";

            return await _connection.QueryAsync<MoneyTransferEntity>(sql, new { OriginPersonId = id, TransferDate = date });
        }

        public async Task<IEnumerable<MoneyTransferEntity>> GetTransfersByDatesAsync(Guid id, DateTime? start, DateTime? end)
        {
            var sql = @"
            SELECT id, origin_person_id AS OriginPersonId, destination_person_id AS DestinationPersonId, 
            transfer_amount AS TransferAmount, transfer_date AS TransferDate
            FROM money_transfers
            WHERE origin_person_id = @OriginPersonId
            AND transfer_date BETWEEN @StartDate AND @EndDate;
            ";

            return await _connection.QueryAsync<MoneyTransferEntity>(sql, new
            {
                OriginPersonId = id,
                StartDate = start,
                EndDate = end
            });
        }

        public async Task<IEnumerable<MoneyTransferEntity>> GetTransfersByUserAsync(Guid id)
        {
            var sql = @"
            SELECT id, origin_person_id AS OriginPersonId, destination_person_id AS DestinationPersonId, 
                   transfer_amount AS TransferAmount, transfer_date AS TransferDate
            FROM money_transfers
            WHERE origin_person_id = @OriginPersonId;
            ";

            return await _connection.QueryAsync<MoneyTransferEntity>(sql, new { OriginPersonId = id });
        }
    }
}
