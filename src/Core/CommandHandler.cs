using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ResultCore;
using Seedwork.DomainDriven.Core;

namespace Seedwork.CQRS.Core
{
    public abstract class CommandHandler<T> : IRequestHandler<T, Result> where T : Command
    {
        public async Task<Result> Handle(T request, CancellationToken cancellationToken)
        {
            try
            {
                await HandleAsync(request, cancellationToken);
                return Result.Success();
            }
            catch (DomainException ex)
            {
                return Result.Fail(ex.Message);
            }
        }

        protected abstract Task HandleAsync(T request, CancellationToken cancellationToken);
    }

    public abstract class CommandHandler<T, TResponse> : IRequestHandler<T, Result> where T : Command<TResponse>
    {
        public async Task<Result> Handle(T request, CancellationToken cancellationToken)
        {
            try
            {
                var response = await HandleAsync(request, cancellationToken);
                return Result.Success(response);
            }
            catch (DomainException ex)
            {
                return Result.Fail(ex.Message);
            }
        }

        protected abstract Task<TResponse> HandleAsync(T request, CancellationToken cancellationToken);
    }
}