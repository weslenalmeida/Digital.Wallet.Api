using Domain.Commands.v1.GenerateToken;

namespace Tests.Shared.Commands.v1.GenerateToken
{
    public static class GenerateTokenCommandMock
    {
        public static GenerateTokenCommand GetDefault() =>
            new GenerateTokenCommand
            {
                Email = "teste@teste.com",
                Password = "tesefgdfgd"
            };
    }
}