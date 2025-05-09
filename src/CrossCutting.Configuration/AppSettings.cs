using CrossCutting.Configuration.AppModels;
using Motors.Wsn.Authentication.Configuration.AppModels;

namespace CrossCutting.Configuration
{
    public static class AppSettings
    {
        public static TokenConfiguration TokenConfiguration { get { return new TokenConfiguration(); } }
        public static SaltConfiguration SaltConfiguration { get { return new SaltConfiguration(); } }
    }
}