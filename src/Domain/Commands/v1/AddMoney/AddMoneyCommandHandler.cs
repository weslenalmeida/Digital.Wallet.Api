using Domain.Interfaces.v1.Context;
using Domain.Interfaces.v1.Repositories;
using Domain.Models.v1;
using MediatR;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Domain.Commands.v1.AddMoney
{
    public class AddMoneyCommandHandler : IRequestHandler<AddMoneyCommand, Unit>
    {
        private readonly IPersonRepository _userAccess;
        private readonly ILogger<AddMoneyCommandHandler> _logger;
        private readonly UserInformation _userInformation;

        public AddMoneyCommandHandler(IPersonRepository userRepository, IContext context, ILogger<AddMoneyCommandHandler> logger)
        {
            _logger = logger;
            _userAccess = userRepository;
            _userInformation = context.GetContext<UserInformation>("UserInformation");
        }

        public async Task<Unit> Handle(AddMoneyCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Start AddMoneyCommandHandler | Request={JsonConvert.SerializeObject(request)}");

            var balance = await _userAccess.GetAccountBalanceAsync(_userInformation.UserId);

            await _userAccess.UpdateAccountBalanceAsync(_userInformation.UserId, balance + request.Amount);

            _logger.LogInformation("End AddMoneyCommandHandler");

            return Unit.Value;
        }
    }
}
