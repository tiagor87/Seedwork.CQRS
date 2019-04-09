using System.Threading;
using System.Threading.Tasks;
using ResultCore;
using Seedwork.CQRS.Core;

namespace Seedwork.CQRS.UnitTests.Stubs
{
    public class VoidCommandStub : Command
    {
        public class VoidCommandStubHandler : CommandHandler<VoidCommandStub>
        {
            protected override Task<Result> HandleAsync(VoidCommandStub request, CancellationToken cancellationToken)
            {
                return Task.FromResult(Result.Success());
            }
        }
    }
}