using Microsoft.Extensions.Configuration;
using System.Net;

namespace CrossCutting.Exceptions
{
    public abstract class BaseException : System.Exception
    {
        public HttpStatusCode StatusCode { get; set; }
        public object? CustomMessage { get; set; }

        public BaseException(HttpStatusCode statusCode, string customException)
        {
            StatusCode = statusCode;
            CustomMessage = GetExceptionMessage(customException);
        }

        public BaseException(HttpStatusCode statusCode)
        {
            StatusCode = statusCode;
        }

        private static IConfigurationRoot Builder()
        {
            var teste = Directory.GetCurrentDirectory();
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("resources.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();

            return builder.Build();
        }

        private static string? GetExceptionMessage(string customException)
        {
            var resources = Builder().GetSection("resource");

            foreach (IConfigurationSection section in resources.GetChildren())
            {
                if (section.GetValue<string>("key") == customException)
                    return section?.GetValue<string>("value");
            }
            return null;
        }
    }
}
