using MediatR;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Calculator.Application
{
    public class LogHandler : IRequestHandler<LogRequest, string>
    {
        private readonly IHttpClientFactory _clientFactory;

        public LogHandler(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<string> Handle(LogRequest request, CancellationToken cancellationToken)
        {
            var client = _clientFactory.CreateClient("logService");
            var response = await client.GetAsync($"https://localhost:5001/api/log/compute?n={request.a}&x={request.b}", cancellationToken);

            return response.Content.ReadAsStringAsync(cancellationToken).Result;
        }
    }
}
