namespace Domain.Models.Shared
{
    public class BaseResponse
    {
        public object Data { get; set; }
        public object Notification { get; set; }

        public BaseResponse(object response, bool error = false)
        {
            if (error)
            {
                Data = response;
            }
            else
            {
                Notification = response;
            }
        }
    }
}
