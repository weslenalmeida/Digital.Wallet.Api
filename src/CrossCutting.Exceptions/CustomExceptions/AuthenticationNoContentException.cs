using CrossCutting.Exceptions;
using System.Net;

namespace CrossCutting.Exception.CustomExceptions
{
    public class AuthenticationNoContentException : BaseException
    {
        public AuthenticationNoContentException() : base(HttpStatusCode.NoContent)
        {
        }
    }
}