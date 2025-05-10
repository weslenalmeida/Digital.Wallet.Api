using Domain.Commands.v1.User;
using Microsoft.Extensions.Logging;
using Moq;
using Tests.Shared.Infrastructure.v1.UserRepositoy;

namespace Tests.Unity.Domain.Commands.v1.User
{
    [TestFixture]
    public class CreateUserCommandHandlerTest
    {
        private static CreateUserCommandHandler GetContext()
        {
            return new CreateUserCommandHandler(
                new UserRepositoryMock().SetUpSuccess(),
                new Mock<ILogger<CreateUserCommandHandler>>().Object
            );
        }

        [Test]
        public void Can_Create_User_Sucess()
        {
            Assert.DoesNotThrowAsync(async () => { await GetContext().Handle(new CreateUserCommand(), CancellationToken.None); });
        }
    }
}
