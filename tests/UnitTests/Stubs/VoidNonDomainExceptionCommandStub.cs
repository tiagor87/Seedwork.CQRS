using System;
using System.Threading;
using System.Threading.Tasks;
using Seedwork.CQRS.Core;

namespace Seedwork.CQRS.UnitTests.Stubs
{
    public class VoidNonDomainExceptionCommandStub : Command
    {
        public class ExceptionCommandStubHandler : CommandHandler<VoidNonDomainExceptionCommandStub>
        {
            protected override Task HandleAsync(VoidNonDomainExceptionCommandStub request,
                CancellationToken cancellationToken)
            {
                throw new Exception("Exception message");
            }
        }
    }
}