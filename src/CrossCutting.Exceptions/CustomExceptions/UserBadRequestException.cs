using CrossCutting.Exceptions;
using System.Net;

namespace CrossCutting.Exception.CustomExceptions
{
    public class UserBadRequestException : BaseException
    {
        public UserBadRequestException() : base(HttpStatusCode.BadRequest, "UserBadRequestException")
        {
        }
    }
}