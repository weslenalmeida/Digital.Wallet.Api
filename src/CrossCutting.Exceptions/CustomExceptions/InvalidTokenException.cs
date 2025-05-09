using CrossCutting.Exceptions;
using System.Net;

namespace CrossCutting.Exception.CustomExceptions
{
    public class InvalidTokenException : BaseException
    {
        public InvalidTokenException() : base(HttpStatusCode.Unauthorized, "InvalidTokenException")
        {
        }
    }
}