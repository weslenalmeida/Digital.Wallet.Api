using CrossCutting.Exceptions;
using System.Net;

namespace CrossCutting.Exception.CustomExceptions
{
    public class InternalErrorException : BaseException
    {
        public InternalErrorException() : base(HttpStatusCode.InternalServerError, "InternalErrorException")
        {
        }
    }
}