using Calculator.Application;
using Lib.Common.Tracing;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Calculator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ITracing _tracing;

        public CalculatorController(IMediator mediator, ITracing tracing)
        {
            _mediator = mediator;
            _tracing = tracing;
        }

        [HttpGet("log")]
        public async Task<ActionResult> ComputeLogAsync(int n, int x)
        {
            var request = new LogRequest()
            {
                a = n,
                b = x
            };

            _tracing.Start(nameof(LogRequest), "PushNotification");

            var result = await _mediator.Send(request);

            return Ok(result);
        }
    }
}
