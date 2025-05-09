using CrossCutting.Exceptions;
using System.Net;

namespace CrossCutting.Exception.CustomExceptions
{
    public class UserNotFoundException : BaseException
    {
        public UserNotFoundException() : base(HttpStatusCode.NotFound, "UserNotFoundException")
        {
        }
    }
}