using CrossCutting.Exceptions;
using System.Net;

namespace CrossCutting.Exception.CustomExceptions
{
    public class UnauthorizedException : BaseException
    {
        public UnauthorizedException() : base(HttpStatusCode.Unauthorized, "UnauthorizedException")
        {
        }
    }
}