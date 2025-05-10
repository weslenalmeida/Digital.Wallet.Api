using CrossCutting.Exception.CustomExceptions;
using Domain.Interfaces.v1.Repositories;
using Domain.Security.v1;
using MediatR;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Motors.Wsn.Authentication.Domain.Fixed.v1;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;

namespace Domain.Commands.v1.GenerateToken
{
    public class GenerateTokenCommandHandler : IRequestHandler<GenerateTokenCommand, GenerateTokenCommandResponse>
    {
        private readonly SigningConfiguration _signingConfiguration;
        private readonly TokenConfiguration _tokenConfiguration;
        private readonly IPersonRepository _userAccess;
        private readonly ILogger<GenerateTokenCommandHandler> _logger;

        public GenerateTokenCommandHandler(IPersonRepository userRepository, ILogger<GenerateTokenCommandHandler> logger)
        {
            _logger = logger;
            _signingConfiguration = new SigningConfiguration();
            _tokenConfiguration = new TokenConfiguration();
            _userAccess = userRepository;
        }

        public async Task<GenerateTokenCommandResponse> Handle(GenerateTokenCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Start GenerateTokenCommandHandler");

            var userAccess = await _userAccess.GetUserAsync(request.Email!, request.Password!) ?? throw new UserBadRequestException();

            if (!userAccess.Activated) throw new UnauthorizedAccessException();

            var createDate = DateTime.UtcNow;
            var expirationDate = createDate.AddSeconds(_tokenConfiguration.Seconds);

            var identity = new ClaimsIdentity
            (
                new GenericIdentity(request.Email!),
                [
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(ClaimType.UserId, userAccess.Id.ToString()),
                    new Claim(ClaimType.Role, userAccess.Role),
                ]
            );

            var token = CreateToken(identity, createDate, expirationDate);

            var response = new GenerateTokenCommandResponse(token, expirationDate);

            _logger.LogInformation("End GenerateTokenCommandHandler");

            return response;
        }

        private string CreateToken(ClaimsIdentity claimsIdentity, DateTime createDate, DateTime expirationDate)
        {
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var securityToken = jwtSecurityTokenHandler.CreateToken
            (
                new SecurityTokenDescriptor()
                {
                    Issuer = _tokenConfiguration.Issuer,
                    Audience = _tokenConfiguration.Audience,
                    SigningCredentials = _signingConfiguration.SigningCredentials,
                    Subject = claimsIdentity,
                    NotBefore = createDate,
                    Expires = expirationDate,

                }
            );

            return jwtSecurityTokenHandler.WriteToken(securityToken);
        }
    }
}