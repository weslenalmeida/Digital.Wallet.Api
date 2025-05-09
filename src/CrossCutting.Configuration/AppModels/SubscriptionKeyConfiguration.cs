namespace CrossCutting.Configuration.AppModels
{
    public class SubscriptionKeyConfiguration
    {
        public string? SubscriptionKey
        {
            get
            {
                return ConfigurationAppSettings.Builder()["SubscriptionKey"];
            }
        }
    }
}
