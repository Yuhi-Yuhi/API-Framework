using Microsoft.Extensions.Configuration;


namespace Framework
{
    public static class Config
    {
        private static readonly IConfigurationRoot configuration;

        static Config()
        {
            configuration = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false)
                .AddEnvironmentVariables()
                .Build();
        }
        
        public static string BaseUrl
        {
            get
            {
                var envBaseUrl = Environment.GetEnvironmentVariable("BASE_URL");
                var baseUrl = !string.IsNullOrWhiteSpace(envBaseUrl)
                    ? envBaseUrl
                    : configuration["baseUrl"];

                return baseUrl!.TrimEnd('/') + "/";
            }
        }
    }
}