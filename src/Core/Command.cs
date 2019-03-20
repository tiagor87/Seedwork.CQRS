using System;
using MediatR;
using ResultCore;

namespace Seedwork.CQRS.Core
{
    public abstract class Command : IRequest<Result>
    {
        protected Command()
        {
            CreatedAt = DateTime.UtcNow;
        }

        public DateTime? CreatedAt { get; }
    }

    public abstract class Command<TResponse> : IRequest<Result>
    {
        protected Command()
        {
            CreatedAt = DateTime.UtcNow;
            ResponseType = typeof(TResponse);
        }

        public DateTime? CreatedAt { get; }
        public Type ResponseType { get; }
    }
}