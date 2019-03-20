using System.Threading;
using System.Threading.Tasks;
using Seedwork.CQRS.Core;

namespace Seedwork.CQRS.UnitTests.Stubs
{
    public class VoidDomainExceptionCommandStub : Command
    {
        public class DomainExceptionCommandStubHandler : CommandHandler<VoidDomainExceptionCommandStub>
        {
            protected override Task HandleAsync(VoidDomainExceptionCommandStub request,
                CancellationToken cancellationToken)
            {
                throw new StubException();
            }
        }
    }
}