using MediatR;

namespace Domain.Queries.v1.Transfer
{
    public class GetTranfersQuery : IRequest<GetTranfersQueryResponse>
    {
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }

        public GetTranfersQuery(DateTime? start, DateTime? end)
        {
            Start = start;
            End = end;
        }
    }
}
