using Domain.Interfaces.v1.Repositories;
using NSubstitute;
using NUnit.Framework;

namespace Tests.Shared.Infrastructure.v1.UserRepositoy
{
    public class UserRepositoryMock
    {
        readonly IPersonRepository mock = Substitute.For<IPersonRepository>();

        [SetUp]
        public IPersonRepository SetUpSuccess()
        {
            mock.UpdateAccountBalanceAsync(Guid.NewGuid(), 123).ReturnsForAnyArgs(true);
            mock.GetAccountBalanceAsync(Guid.NewGuid()).ReturnsForAnyArgs(100);
            mock.GetUserAsync("email", "password").ReturnsForAnyArgs(Task.FromResult(new Domain.Entities.v1.PersonEntity { Id = Guid.NewGuid(), Role = "role", Activated = true }));
            mock.CreateUserAsync(new Domain.Entities.v1.PersonEntity(new Domain.Commands.v1.User.CreateUserCommand()));
            return mock;
        }

        [SetUp]
        public IPersonRepository SetUpFailed()
        {
            mock.GetUserAsync("email", "password").ReturnsForAnyArgs(Task.FromResult(new Domain.Entities.v1.PersonEntity { Id = Guid.NewGuid(), Role = "role", Activated = false }));
            return mock;
        }
    }
}