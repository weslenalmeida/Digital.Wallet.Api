using Domain.Entities.v1;

namespace Domain.Queries.v1.Transfer
{
    public class GetTranfersQueryResponse
    {
        public IEnumerable<MoneyTransferEntity> Transfers { get; set; }

        public GetTranfersQueryResponse(IEnumerable<MoneyTransferEntity> transfers)
        {
            Transfers = transfers;
        }
    }
}
