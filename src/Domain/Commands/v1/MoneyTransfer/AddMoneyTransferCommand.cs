using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Domain.Commands.v1.MoneyTransfer
{
    public class AddMoneyTransferCommand : IRequest<Unit>
    {
        [Required]
        public Guid DestinationUserId { get; set; }

        [Required]
        public decimal TransferAmount { get; set; }
    }
}
