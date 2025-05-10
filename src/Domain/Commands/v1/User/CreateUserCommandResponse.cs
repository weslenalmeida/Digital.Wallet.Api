namespace Domain.Commands.v1.User
{
    public class CreateUserCommandResponse
    {
        public Guid UserId { get; set; }

        public CreateUserCommandResponse(Guid userId)
        {
            UserId = userId;
        }
    }
}
