namespace Domain.Queries.v1.AccountBalance
{
    public class GetAccountBalanceQueryResponse
    {
        public decimal? Balance { get; set; }

        public GetAccountBalanceQueryResponse(decimal? balance)
        {
            Balance = balance;
        }
    }
}
