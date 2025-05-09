using CrossCutting.Configuration;

namespace Motors.Wsn.Authentication.Configuration.AppModels
{
    public class SaltConfiguration
    {
        public string? Salt
        {
            get
            {
                return ConfigurationAppSettings.Builder()["Salt"];
            }
        }
    }
}
