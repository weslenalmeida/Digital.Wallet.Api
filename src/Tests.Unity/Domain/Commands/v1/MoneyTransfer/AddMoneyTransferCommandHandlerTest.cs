using CrossCutting.Exceptions.CustomExceptions;
using Domain.Commands.v1.MoneyTransfer;
using Microsoft.Extensions.Logging;
using Moq;
using Tests.Shared.Context;
using Tests.Shared.Infrastructure.v1.TransferRepository;
using Tests.Shared.Infrastructure.v1.UserRepositoy;

namespace Tests.Unity.Domain.Commands.v1.MoneyTransfer
{
    [TestFixture]
    public class AddMoneyTransferCommandHandlerTest
    {
        private static AddMoneyTransferCommandHandler GetContext()
        {
            return new AddMoneyTransferCommandHandler(
                new UserRepositoryMock().SetUpSuccess(),
                new TransferRepositoryMock().SetUpSuccess(),
                 new ContextNotEmptyMock().GetContext(),
                new Mock<ILogger<AddMoneyTransferCommandHandler>>().Object
            );
        }

        private static AddMoneyTransferCommandHandler GetFailedContext()
        {
            return new AddMoneyTransferCommandHandler(
                new UserRepositoryMock().SetUpSuccess(),
                new TransferRepositoryMock().SetUpSuccess(),
                 new ContextNotEmptyMock().GetContext(),
                new Mock<ILogger<AddMoneyTransferCommandHandler>>().Object
            );
        }
        [Test]
        public void Can_Add_Money_Transfer_Sucess()
        {
            Assert.DoesNotThrowAsync(async () => { await GetContext().Handle(new AddMoneyTransferCommand { DestinationUserId = Guid.NewGuid(), TransferAmount = 90 }, CancellationToken.None); });
        }

        [Test]
        public void Can_Add_Money_Transfer_Failed()
        {
            Assert.ThrowsAsync<AmountBalanceException>(async () => { await GetFailedContext().Handle(new AddMoneyTransferCommand { DestinationUserId = Guid.NewGuid(), TransferAmount = 150 }, CancellationToken.None); });
        }
    }
}
