using System;
using System.Threading;
using System.Threading.Tasks;
using ResultCore;
using Seedwork.CQRS.Core;

namespace Seedwork.CQRS.UnitTests.Stubs
{
    public class VoidNonDomainExceptionCommandStub : Command
    {
        public class ExceptionCommandStubHandler : CommandHandler<VoidNonDomainExceptionCommandStub>
        {
            protected override Task<Result> HandleAsync(VoidNonDomainExceptionCommandStub request,
                CancellationToken cancellationToken)
            {
                throw new Exception("Exception message");
            }
        }
    }
}