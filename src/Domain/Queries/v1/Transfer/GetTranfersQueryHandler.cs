using CrossCutting.Exceptions.CustomExceptions;
using Domain.Entities.v1;
using Domain.Interfaces.v1.Context;
using Domain.Interfaces.v1.Repositories;
using Domain.Models.v1;
using MediatR;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Domain.Queries.v1.Transfer
{
    public class GetTranfersQueryHandler : IRequestHandler<GetTranfersQuery, GetTranfersQueryResponse>
    {
        private readonly IPersonRepository _userAccess;
        private readonly ITransferRepository _transfer;
        private readonly ILogger<GetTranfersQueryHandler> _logger;
        private readonly UserInformation _userInformation;

        public GetTranfersQueryHandler(IPersonRepository userRepository, ITransferRepository transferRepository, IContext context, ILogger<GetTranfersQueryHandler> logger)
        {
            _logger = logger;
            _userAccess = userRepository;
            _transfer = transferRepository;
            _userInformation = context.GetContext<UserInformation>("UserInformation");
        }

        public async Task<GetTranfersQueryResponse> Handle(GetTranfersQuery query, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Start GetTranfersQueryHandler | Request={JsonConvert.SerializeObject(query)}");

            GetTranfersQueryResponse tranfers;

            if (query.Start is null && query.End is null)
                tranfers = new GetTranfersQueryResponse(VerifyEmptyList(await _transfer.GetTransfersByUserAsync(_userInformation.UserId)));

            else if (query.Start is not null && query.End is null)
                tranfers = new GetTranfersQueryResponse(VerifyEmptyList(await _transfer.GetTransfersByDateAsync(_userInformation.UserId, query.Start)));

            else if ((query.Start is not null && query.End is not null) && (query.Start < query.End))
                tranfers = new GetTranfersQueryResponse(VerifyEmptyList(await _transfer.GetTransfersByDatesAsync(_userInformation.UserId, query.Start, query.End)));

            else
                throw new ApiBadRequestException();

            _logger.LogInformation("End GetTranfersQueryHandler");

            return tranfers;
        }

        private IEnumerable<MoneyTransferEntity> VerifyEmptyList(IEnumerable<MoneyTransferEntity> entities) =>
            entities is not null && entities.Any() ? entities : throw new ApiNoContentException();
    }
}
