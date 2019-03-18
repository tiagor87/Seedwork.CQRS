using System.Threading;
using System.Threading.Tasks;
using Seedwork.CQRS.Core;

namespace Seedwork.CQRS.UnitTests.Stubs
{
    public class ResultCommandStub : Command<object>
    {
        public ResultCommandStub(object value)
        {
            Value = value;
        }

        public object Value { get; }

        public class ResultCommandStubHandler : CommandHandler<ResultCommandStub, object>
        {
            protected override Task<object> HandleAsync(ResultCommandStub request, CancellationToken cancellationToken)
            {
                return Task.FromResult(request.Value);
            }
        }
    }
}