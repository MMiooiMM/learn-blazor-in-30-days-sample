using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Blazor30days.Helpers
{
    public class FakeHttpClientHandler : HttpClientHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (request.RequestUri.AbsolutePath == "/auth" && request.Method == HttpMethod.Get)
            {
                return new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK
                };
            }
            else
            {
                return await base.SendAsync(request, cancellationToken);
            }
        }
    }
}