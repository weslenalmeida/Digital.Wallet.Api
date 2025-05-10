using Domain.Commands.v1.AddMoney;
using Microsoft.Extensions.Logging;
using Moq;
using Tests.Shared.Context;
using Tests.Shared.Infrastructure.v1.UserRepositoy;

namespace Tests.Unity.Domain.Commands.v1.AddMoney
{
    [TestFixture]
    public class AddMoneyCommandHandlerTest
    {
        private static AddMoneyCommandHandler GetContext()
        {
            return new AddMoneyCommandHandler(
                new UserRepositoryMock().SetUpSuccess(),
                new ContextNotEmptyMock().GetContext(),
                new Mock<ILogger<AddMoneyCommandHandler>>().Object
            );
        }

        [Test]
        public void Can_Add_Money_Sucess()
        {
            Assert.DoesNotThrowAsync(async () => { await GetContext().Handle(new AddMoneyCommand { Amount = 10 }, CancellationToken.None); });
        }
    }
}
