using Domain.Interfaces.v1.Context;
using Domain.Interfaces.v1.Repositories;
using Domain.Models.v1;
using MediatR;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Domain.Queries.v1.AccountBalance
{
    public class GetAccountBalanceQueryHandler : IRequestHandler<GetAccountBalanceQuery, GetAccountBalanceQueryResponse>
    {
        private readonly IPersonRepository _userAccess;
        private readonly ILogger<GetAccountBalanceQueryHandler> _logger;
        private readonly UserInformation _userInformation;

        public GetAccountBalanceQueryHandler(IPersonRepository userRepository, IContext context, ILogger<GetAccountBalanceQueryHandler> logger)
        {
            _logger = logger;
            _userAccess = userRepository;
            _userInformation = context.GetContext<UserInformation>("UserInformation");
        }

        public async Task<GetAccountBalanceQueryResponse> Handle(GetAccountBalanceQuery query, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Start GetAccountBalanceQueryHandler | Request={JsonConvert.SerializeObject(query)}");

            var accountBalance = await _userAccess.GetAccountBalanceAsync(_userInformation.UserId);

            _logger.LogInformation("End GetAccountBalanceQueryHandler");

            return new GetAccountBalanceQueryResponse(accountBalance);
        }
    }
}
