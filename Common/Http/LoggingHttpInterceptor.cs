using Serilog;

namespace Framework.Common.Http
{
    public class LoggingHttpInterceptor : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            Log.Information("HTTP {Method} {Url}", request.Method, request.RequestUri);

            var response = await base.SendAsync(request, cancellationToken);

            Log.Information("RESPONSE {StatusCode}", response.StatusCode);
            return response;
        }
    }
}