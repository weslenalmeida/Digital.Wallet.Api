namespace Domain.Models.v1
{
    public class UserInformation
    {
        public Guid UserId { get; set; }
        public string Role { get; set; }

        public UserInformation(Guid userId, string role)
        {
            UserId = userId;
            Role = role;
        }
    }
}