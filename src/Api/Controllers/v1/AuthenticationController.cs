using Api.Filter;
using Api.Shared;
using Domain.Commands.v1.GenerateToken;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Application.Controllers.v1
{
    [Route("api/v1/authentication")]
    public class AuthenticationController(ISender mediator, ILogger<AuthenticationController> logger) : BaseController<AuthenticationController>(mediator, logger)
    {
        [HeaderContext]
        [HttpPost("token")]
        [ProducesResponseType(typeof(GenerateTokenCommandResponse), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> GenerateTokenAsync([FromBody] GenerateTokenCommand request)
        {
            return await GenerateHttpResponse(request, HttpStatusCode.Created);
        }
    }
}