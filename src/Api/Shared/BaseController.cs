using CrossCutting.Exceptions;
using Domain.Models.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;

namespace Api.Shared
{
    public abstract class BaseController<T>(ISender mediator, ILogger<T> logger) : ControllerBase
    {
        private readonly ISender _mediator = mediator;
        private readonly ILogger<T> _logger = logger;

        protected async Task<IActionResult> GenerateHttpResponse(object request, HttpStatusCode statusCode)
        {
            try
            {
                _logger.LogInformation("Start request Api");
                var response = await _mediator.Send(request);
                return StatusCode((int)statusCode, new BaseResponse(response));
            }
            catch (BaseException ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode((int)ex.StatusCode, new BaseResponse(ex.CustomMessage, true));
            }
            catch (Exception ex)
            {
                _logger.LogError(JsonConvert.SerializeObject(ex));
                return StatusCode((int)HttpStatusCode.InternalServerError, new BaseResponse(ex.Message, true));
            }
        }
    }
}
