namespace Framework.Common.Http
{
    public static class HttpClientProvider
    {
        public static HttpClient Create()
        {
            var handler = new LoggingHttpInterceptor 
            { 
                InnerHandler = new HttpClientHandler() 
            };

            return new HttpClient(handler)
            {
                BaseAddress = new Uri(Config.BaseUrl)
            };
        }
    }
}