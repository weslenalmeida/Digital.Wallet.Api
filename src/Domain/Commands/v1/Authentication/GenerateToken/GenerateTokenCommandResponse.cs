namespace Domain.Commands.v1.GenerateToken
{
    public class GenerateTokenCommandResponse
    {
        public string? AccessToken { get; set; }
        public DateTime ExpirationDate { get; set; }

        public GenerateTokenCommandResponse(string token, DateTime expirationDate)
        {
            AccessToken = token;
            ExpirationDate = expirationDate;
        }
    }
}