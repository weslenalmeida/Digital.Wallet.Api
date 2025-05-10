using Domain.Entities.v1;
using Domain.Interfaces.v1.Repositories;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using NUnit.Framework;

namespace Tests.Shared.Infrastructure.v1.TransferRepository
{
    public class TransferRepositoryMock
    {
        readonly ITransferRepository mock = Substitute.For<ITransferRepository>();

        [SetUp]
        public ITransferRepository SetUpSuccess()
        {
            mock.GetTransfersByDateAsync(Guid.NewGuid(), DateTime.Now)
                .Returns(new List<MoneyTransferEntity> { new MoneyTransferEntity { DestinationPersonId = Guid.NewGuid(), Id = Guid.NewGuid(), OriginPersonId = Guid.NewGuid(), TransferAmount = 10, TransferDate = DateTime.Now } });
            mock.GetTransfersByDatesAsync(Guid.NewGuid(), DateTime.Now, DateTime.Now)
                .Returns(new List<MoneyTransferEntity> { new MoneyTransferEntity { DestinationPersonId = Guid.NewGuid(), Id = Guid.NewGuid(), OriginPersonId = Guid.NewGuid(), TransferAmount = 10, TransferDate = DateTime.Now } });
            mock.GetTransfersByUserAsync(Guid.NewGuid())
                .Returns(new List<MoneyTransferEntity> { new MoneyTransferEntity { DestinationPersonId = Guid.NewGuid(), Id = Guid.NewGuid(), OriginPersonId = Guid.NewGuid(), TransferAmount = 10, TransferDate = DateTime.Now } });
            return mock;
        }

        [SetUp]
        public ITransferRepository SetUpFailed()
        {
            mock.GetTransfersByDateAsync(Guid.NewGuid(), DateTime.Now)
                .ReturnsNull();

            return mock;
        }
    }
}
