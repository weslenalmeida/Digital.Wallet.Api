using Domain.Models.v1;

namespace Domain.Entities.v1
{
    public class PersonEntity
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Document { get; set; }
        public DateTime BirthDate { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public bool Activated { get; set; }
        public string? Role { get; set; }
        public DateTime RegistrationDate { get; set; }
        public decimal AccountBalance { get; set; }
    }
}