using Application.Shared;
using CrossCutting.Configuration;
using CrossCutting.Exception.CustomExceptions;
using Domain.Models.v1;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.IdentityModel.Tokens.Jwt;

namespace Application.Filter
{
    [AttributeUsage(validOn: AttributeTargets.Class | AttributeTargets.Method)]
    public class HeaderContext : Attribute, IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            try
            {
                context.HttpContext.Request.Headers.TryGetValue("Token", out var token);

                var handler = new JwtSecurityTokenHandler();
                var jwtSecurityToken = handler.ReadJwtToken(token);
                var issuer = jwtSecurityToken.Claims.First(claim => claim.Type == "iss").Value;
                var audience = jwtSecurityToken.Claims.First(claim => claim.Type == "aud").Value;
                var userId = jwtSecurityToken.Claims.First(claim => claim.Type == "userId").Value;
                var role = jwtSecurityToken.Claims.First(claim => claim.Type == "role").Value;

                if (!issuer.Equals(AppSettings.TokenConfiguration.Issuer) && !audience.Equals(AppSettings.TokenConfiguration.Audience))
                    throw new UnauthorizedException();

                Holder.Context.AddOrOverwriteContext("userInformation", new UserInformation(Guid.Parse(userId), role));

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