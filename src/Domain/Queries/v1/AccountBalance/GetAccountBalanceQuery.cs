using MediatR;

namespace Domain.Queries.v1.AccountBalance
{
    public class GetAccountBalanceQuery : IRequest<GetAccountBalanceQueryResponse>
    {
    }
}
