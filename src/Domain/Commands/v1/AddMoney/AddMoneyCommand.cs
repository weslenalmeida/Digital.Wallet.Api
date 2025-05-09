using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Domain.Commands.v1.AddMoney
{
    public class AddMoneyCommand : IRequest<Unit>
    {
        [Required]
        public decimal Amount { get; set; }
    }
}
