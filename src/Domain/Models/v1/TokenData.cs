namespace Domain.Models.v1
{
    public class TokenData(string email, DateTime expirateDate)
    {
        public string Email { get; set; } = email;
        public DateTime ExpirateDate { get; set; } = expirateDate;
    }
}