using System;
using System.Threading;
using System.Threading.Tasks;
using Seedwork.CQRS.Core;

namespace Seedwork.CQRS.UnitTests.Stubs
{
    public class ResultNonDomainExceptionCommandStub : Command<object>
    {
        public class ResultExceptionCommandStubHandler : CommandHandler<ResultNonDomainExceptionCommandStub, object>
        {
            protected override Task<object> HandleAsync(ResultNonDomainExceptionCommandStub request,
                CancellationToken cancellationToken)
            {
                throw new Exception("Exception message");
            }
        }
    }
}