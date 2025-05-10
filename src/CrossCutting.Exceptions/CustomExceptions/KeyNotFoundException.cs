using CrossCutting.Exceptions;
using System.Net;

namespace CrossCutting.Exception.CustomExceptions
{
    public class KeyNotFoundException : BaseException
    {
        public KeyNotFoundException() : base(HttpStatusCode.NotFound, "KeyNotFoundExceptionBaseException")
        {
        }
    }
}