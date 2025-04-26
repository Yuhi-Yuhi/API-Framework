using System.Configuration;


namespace Framework
{
    public static class ConfigurationManager
    {
        public static string BaseUrl => System.Configuration.ConfigurationManager.AppSettings["BaseUrl"];
    }
}