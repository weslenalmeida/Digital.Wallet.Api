using Api.Filter;
using Api.Shared;
using Domain.Commands.v1.MoneyTransfer;
using Domain.Queries.v1.Transfer;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Api.Controllers.v1
{
    [Route("api/v1/transfers")]
    public class TransferController(ISender mediator, ILogger<TransferController> logger) : BaseController<TransferController>(mediator, logger)
    {
        [HeaderContext]
        [HttpPost]
        [ProducesResponseType(typeof(Unit), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> AddMoneyTransfer([FromBody] AddMoneyTransferCommand request)
        {
            return await GenerateHttpResponse(request, HttpStatusCode.OK);
        }

        [HeaderContext]
        [HttpGet]
        [ProducesResponseType(typeof(GetTranfersQueryResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetTranfersAsync([FromQuery] DateTime? start, DateTime? end)
        {
            return await GenerateHttpResponse(new GetTranfersQuery(start, end), HttpStatusCode.OK);
        }
    }
}
