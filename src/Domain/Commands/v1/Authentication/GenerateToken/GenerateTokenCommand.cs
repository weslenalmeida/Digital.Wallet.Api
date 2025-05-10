using Domain.Security.v1;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Domain.Commands.v1.GenerateToken
{
    public class GenerateTokenCommand : IRequest<GenerateTokenCommandResponse>
    {
        private string _password;

        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "Input invalid email!")]
        public string? Email { get; set; }

        [Required]
        [DataType(DataType.Password, ErrorMessage = "Input invalid password!")]
        public string Password { get => _password; set => _password = CryptoPassword.Encode(value); }
    }
}