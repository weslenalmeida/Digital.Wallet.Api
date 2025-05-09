using Application.Shared;
using CrossCutting.Configuration;
using CrossCutting.Exception.CustomExceptions;
using Domain.Models.v1;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.IdentityModel.Tokens.Jwt;
using System.Net;

namespace Api.Filter
{
    [AttributeUsage(validOn: AttributeTargets.Class | AttributeTargets.Method)]
    public class HeaderContext : Attribute, IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            try
            {
                context.HttpContext.Request.Headers.TryGetValue("Ocp-Apim-Subscription-Key", out var subscriptionKey);

                if (subscriptionKey != AppSettings.SubscriptionKeyConfiguration.SubscriptionKey) throw new UnauthorizedException();

                var path = context.HttpContext.Request.Path.Value?.ToLower();

                if ((!path.Contains("api/v1/authentication/token")) || (context.HttpContext.Request.Method == WebRequestMethods.Http.Post && path.Contains("api/v1/users")))
                {
                    context.HttpContext.Request.Headers.TryGetValue("Token", out var token);

                    var handler = new JwtSecurityTokenHandler();
                    var jwtSecurityToken = handler.ReadJwtToken(token);
                    var userId = jwtSecurityToken.Claims.First(claim => claim.Type == "userId").Value;
                    var role = jwtSecurityToken.Claims.First(claim => claim.Type == "role").Value;

                    Holder.Context.AddOrOverwriteContext("userInformation", new UserInformation(Guid.Parse(userId), role));
                }

                await next();
            }
            catch (Exception ex)
            {
                context.Result = new UnauthorizedResult();
                Console.WriteLine($"Error to get token on header {ex.Message}");
            }
        }
    }
}