using System.Net;

namespace CrossCutting.Exceptions.CustomExceptions
{
    public class ApiNoContentException : BaseException
    {
        public ApiNoContentException() : base(HttpStatusCode.NoContent)
        {
        }
    }
}
