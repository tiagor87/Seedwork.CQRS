using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ResultCore;

namespace Seedwork.CQRS.Core
{
    public abstract class CommandHandler<T> : IRequestHandler<T, Result> where T : Command
    {
        public async Task<Result> Handle(T request, CancellationToken cancellationToken)
        {
            try
            {
                return await HandleAsync(request, cancellationToken);
            }
            catch (DomainException ex)
            {
                return Result.Fail(ex.Message);
            }
        }

        protected abstract Task<Result> HandleAsync(T request, CancellationToken cancellationToken);
    }

    public abstract class CommandHandler<T, TResponse> : IRequestHandler<T, Result<TResponse>>
        where T : Command<TResponse>
    {
        public async Task<Result<TResponse>> Handle(T request, CancellationToken cancellationToken)
        {
            try
            {
                return await HandleAsync(request, cancellationToken);
            }
            catch (DomainException ex)
            {
                return Result<TResponse>.Fail(ex.Message);
            }
        }

        protected abstract Task<Result<TResponse>> HandleAsync(T request, CancellationToken cancellationToken);
    }
}