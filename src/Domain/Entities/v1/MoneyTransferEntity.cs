namespace Domain.Entities.v1
{
    public class MoneyTransferEntity : BaseEntity
    {

        public Guid OriginPersonId { get; set; }
        public Guid DestinationPersonId { get; set; }
        public decimal TransferAmount { get; set; }
        public DateTime TransferDate { get; set; }


    }
}
