using System.Net;

namespace CrossCutting.Exceptions.CustomExceptions
{
    public class ApiBadRequestException : BaseException
    {
        public ApiBadRequestException() : base(HttpStatusCode.BadRequest, "ApiBadRequestException")
        {
        }
    }
}
