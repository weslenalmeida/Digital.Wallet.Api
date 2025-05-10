namespace CrossCutting.Configuration.AppModels
{
    public class ConnectionSettings
    {
        public string? ConnectionSqlString
        {
            get
            {
                return ConfigurationAppSettings.Builder()["ConnectionSettings:ConnectionSqlString"];
            }
        }
    }
}
