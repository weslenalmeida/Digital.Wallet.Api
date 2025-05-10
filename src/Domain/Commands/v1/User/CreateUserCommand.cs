using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Domain.Commands.v1.User
{
    public class CreateUserCommand : IRequest<CreateUserCommandResponse>
    {
        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Document { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "Input invalid email!")]
        public string? Email { get; set; }

        [Required]
        [DataType(DataType.Password, ErrorMessage = "Input invalid password!")]
        public string? Password { get; set; }

        [Required]
        public string? Role { get; set; }

        public decimal AccountBalance { get; set; }
    }
}
