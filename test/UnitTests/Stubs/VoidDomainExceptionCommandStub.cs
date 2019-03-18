using System.Threading;
using System.Threading.Tasks;
using Seedwork.CQRS.Core;
using Seedwork.DomainDriven.Core;

namespace Seedwork.CQRS.UnitTests.Stubs
{
    public class VoidDomainExceptionCommandStub : Command
    {
        public class DomainExceptionCommandStubHandler : CommandHandler<VoidDomainExceptionCommandStub>
        {
            protected override Task HandleAsync(VoidDomainExceptionCommandStub request,
                CancellationToken cancellationToken)
            {
                throw new DomainException("Exception message");
            }
        }
    }
}