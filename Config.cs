using Microsoft.Extensions.Configuration;


namespace Framework
{
    public static class Config
    {
        private static IConfigurationRoot configuration;

        static Config()
        {
            configuration = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false)
                .Build();
        }

        public static string BaseUrl => configuration["baseUrl"];
    }
}