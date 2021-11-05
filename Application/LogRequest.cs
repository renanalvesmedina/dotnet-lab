using MediatR;

namespace Calculator.Application
{
    public class LogRequest : IRequest<string>
    {
        public int a { get; set; }
        public int b { get; set; }
    }
}
