using Domain.Commands.v1.GenerateToken;
using Microsoft.Extensions.Logging;
using Moq;
using Tests.Shared.Commands.v1.GenerateToken;
using Tests.Shared.Infrastructure.v1.UserRepositoy;

namespace Tests.Unity.Domain.Commands.v1.GenerateToken
{
    [TestFixture]
    public class GenerateTokenCommandHandlerTest
    {
        private static GenerateTokenCommandHandler GetContext()
        {
            return new GenerateTokenCommandHandler(
                new UserRepositoryMock().SetUpSuccess(),
                new Mock<ILogger<GenerateTokenCommandHandler>>().Object
            );
        }

        private static GenerateTokenCommandHandler GetFailedContext()
        {
            return new GenerateTokenCommandHandler(
                new UserRepositoryMock().SetUpFailed(),
                new Mock<ILogger<GenerateTokenCommandHandler>>().Object
            );
        }
        [Test]
        public void Can_Generate_Token_When_Sucess()
        {
            Assert.DoesNotThrowAsync(async () => { await GetContext().Handle(GenerateTokenCommandMock.GetDefault(), CancellationToken.None); });
        }

        [Test]
        public void Can_Generate_Token_When_Failed()
        {
            Assert.ThrowsAsync<UnauthorizedAccessException>(async () => { await GetFailedContext().Handle(GenerateTokenCommandMock.GetDefault(), CancellationToken.None); });
        }
    }
}
