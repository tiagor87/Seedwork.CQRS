using System.Threading;
using System.Threading.Tasks;
using ResultCore;
using Seedwork.CQRS.Core;

namespace Seedwork.CQRS.UnitTests.Stubs
{
    public class ResultDomainExceptionCommandStub : Command<object>
    {
        public class ResultDomainExceptionCommandStubHandler : CommandHandler<ResultDomainExceptionCommandStub, object>
        {
            protected override Task<Result<object>> HandleAsync(ResultDomainExceptionCommandStub request,
                CancellationToken cancellationToken)
            {
                throw new StubException();
            }
        }
    }
}