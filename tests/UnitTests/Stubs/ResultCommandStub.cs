using System.Threading;
using System.Threading.Tasks;
using Seedwork.CQRS.Core;

namespace Seedwork.CQRS.UnitTests.Stubs
{
    public class ResultCommandStub : Command<long>
    {
        public ResultCommandStub(long value)
        {
            Value = value;
        }

        public long Value { get; }

        public class ResultCommandStubHandler : CommandHandler<ResultCommandStub, long>
        {
            protected override Task<long> HandleAsync(ResultCommandStub request, CancellationToken cancellationToken)
            {
                return Task.FromResult(request.Value);
            }
        }
    }
}