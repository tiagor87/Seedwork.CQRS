using System.Threading;
using System.Threading.Tasks;
using Seedwork.CQRS.Core;

namespace Seedwork.CQRS.UnitTests.Stubs
{
    public class ResultDomainExceptionCommandStub : Command<object>
    {
        public class ResultDomainExceptionCommandStubHandler : CommandHandler<ResultDomainExceptionCommandStub, object>
        {
            protected override Task<object> HandleAsync(ResultDomainExceptionCommandStub request,
                CancellationToken cancellationToken)
            {
                throw new StubException();
            }
        }
    }
}