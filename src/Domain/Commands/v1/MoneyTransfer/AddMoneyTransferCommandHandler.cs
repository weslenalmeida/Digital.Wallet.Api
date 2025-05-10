using CrossCutting.Exceptions.CustomExceptions;
using Domain.Interfaces.v1.Context;
using Domain.Interfaces.v1.Repositories;
using Domain.Models.v1;
using MediatR;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Domain.Commands.v1.MoneyTransfer
{
    public class AddMoneyTransferCommandHandler : IRequestHandler<AddMoneyTransferCommand, Unit>
    {
        private readonly IPersonRepository _userAccess;
        private readonly ITransferRepository _transfer;
        private readonly ILogger<AddMoneyTransferCommandHandler> _logger;
        private readonly UserInformation _userInformation;

        public AddMoneyTransferCommandHandler(IPersonRepository userRepository, ITransferRepository transfer, IContext context, ILogger<AddMoneyTransferCommandHandler> logger)
        {
            _logger = logger;
            _userAccess = userRepository;
            _transfer = transfer;
            _userInformation = context.GetContext<UserInformation>("UserInformation");
        }

        public async Task<Unit> Handle(AddMoneyTransferCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Start AddMoneyTransferCommandHandler | Request={JsonConvert.SerializeObject(request)}");

            var userOriginBalance = await _userAccess.GetAccountBalanceAsync(_userInformation.UserId);

            if (ValidadeBalance(request.TransferAmount, userOriginBalance))
            {
                await _userAccess.UpdateAccountBalanceAsync(_userInformation.UserId, userOriginBalance - request.TransferAmount);

                await _userAccess.UpdateAccountBalanceAsync(request.DestinationUserId, userOriginBalance + request.TransferAmount);

                await _transfer.CreateTransferAsync(new Entities.v1.MoneyTransferEntity
                {
                    Id = Guid.NewGuid(),
                    OriginPersonId = _userInformation.UserId,
                    TransferAmount = request.TransferAmount,
                    DestinationPersonId = request.DestinationUserId,
                    TransferDate = DateTime.Now
                });
            }
            else
                throw new AmountBalanceException();

            _logger.LogInformation("End AddMoneyTransferCommandHandler");

            return Unit.Value;
        }

        private bool ValidadeBalance(decimal? transferValue, decimal? balanceValue) =>
            transferValue <= balanceValue;

    }
}
