using Domain.Interfaces.v1.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Domain.Commands.v1.User
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreateUserCommandResponse>
    {
        private readonly IPersonRepository _userAccess;
        private readonly ILogger<CreateUserCommandHandler> _logger;

        public CreateUserCommandHandler(IPersonRepository userRepository, ILogger<CreateUserCommandHandler> logger)
        {
            _logger = logger;
            _userAccess = userRepository;
        }

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Start CreateUserCommandHandler | UserName={JsonConvert.SerializeObject(request?.Name)}");

            var person = new Entities.v1.PersonEntity(request);

            await _userAccess.CreateUserAsync(person);

            _logger.LogInformation("End CreateUserCommandHandler");

            return new CreateUserCommandResponse(person.Id);
        }
    }
}
