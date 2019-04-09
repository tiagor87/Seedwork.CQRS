using System;
using System.Threading;
using System.Threading.Tasks;
using ResultCore;
using Seedwork.CQRS.Core;

namespace Seedwork.CQRS.UnitTests.Stubs
{
    public class ResultNonDomainExceptionCommandStub : Command<object>
    {
        public class ResultExceptionCommandStubHandler : CommandHandler<ResultNonDomainExceptionCommandStub, object>
        {
            protected override Task<Result<object>> HandleAsync(ResultNonDomainExceptionCommandStub request,
                CancellationToken cancellationToken)
            {
                throw new Exception("Exception message");
            }
        }
    }
}