using System.Net;

namespace CrossCutting.Exceptions.CustomExceptions
{
    public class AmountBalanceException : BaseException
    {
        public AmountBalanceException() : base(HttpStatusCode.BadRequest, "AmountBalanceException")
        {
        }
    }
}
