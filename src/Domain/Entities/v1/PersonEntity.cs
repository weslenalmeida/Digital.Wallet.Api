using Domain.Commands.v1.User;

namespace Domain.Entities.v1
{
    public class PersonEntity : BaseEntity
    {
        public string? Name { get; set; }
        public string? Document { get; set; }
        public DateTime BirthDate { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public bool Activated { get; set; }
        public string? Role { get; set; }
        public DateTime RegistrationDate { get; set; }
        public decimal AccountBalance { get; set; }

        public PersonEntity()
        {

        }

        public PersonEntity(CreateUserCommand command)
        {
            Id = Guid.NewGuid();
            Name = command.Name;
            Document = command.Document;
            BirthDate = command.BirthDate;
            Email = command.Email;
            Password = command.Password;
            Activated = true;
            Role = command.Role;
            RegistrationDate = DateTime.Now;
            AccountBalance = command.AccountBalance;
        }
    }
}