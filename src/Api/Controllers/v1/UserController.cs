using Api.Filter;
using Api.Shared;
using Domain.Commands.v1.AddMoney;
using Domain.Commands.v1.User;
using Domain.Queries.v1.AccountBalance;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Api.Controllers.v1
{
    [Route("api/v1/users")]
    public class UserController(ISender mediator, ILogger<UserController> logger) : BaseController<UserController>(mediator, logger)
    {

        [HeaderContext]
        [HttpPost]
        [ProducesResponseType(typeof(CreateUserCommandResponse), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> CreateUserAsync([FromBody] CreateUserCommand request)
        {
            return await GenerateHttpResponse(request, HttpStatusCode.Created);
        }

        [HeaderContext]
        [HttpGet("balance")]
        [ProducesResponseType(typeof(GetAccountBalanceQueryResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAccountBalance()
        {
            return await GenerateHttpResponse(new GetAccountBalanceQuery(), HttpStatusCode.OK);
        }

        [HeaderContext]
        [HttpPatch("balance")]
        [ProducesResponseType(typeof(Unit), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> AddMoneyAsync([FromBody] AddMoneyCommand request)
        {
            return await GenerateHttpResponse(request, HttpStatusCode.OK);
        }


    }
}
