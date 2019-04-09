using System.Threading;
using System.Threading.Tasks;
using ResultCore;
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
            protected override Task<Result<long>> HandleAsync(ResultCommandStub request,
                CancellationToken cancellationToken)
            {
                return Task.FromResult(Result<long>.Success(request.Value));
            }
        }
    }
}