using System.Threading;
using System.Threading.Tasks;
using Seedwork.CQRS.Core;

namespace Seedwork.CQRS.UnitTests.Stubs
{
    public class VoidCommandStub : Command
    {
        public class VoidCommandStubHandler : CommandHandler<VoidCommandStub>
        {
            protected override Task HandleAsync(VoidCommandStub request, CancellationToken cancellationToken)
            {
                return Task.CompletedTask;
            }
        }
    }
}