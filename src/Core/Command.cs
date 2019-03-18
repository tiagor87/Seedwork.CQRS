using System;
using MediatR;
using ResultCore;

namespace Seedwork.CQRS.Core
{
    public abstract class Command : IRequest<Result>
    {
        public Command()
        {
            CreatedAt = DateTime.UtcNow;
        }

        public DateTime? CreatedAt { get; }
    }

    public abstract class Command<T> : IRequest<Result>
    {
        public Command()
        {
            CreatedAt = DateTime.UtcNow;
        }

        public DateTime? CreatedAt { get; }
    }
}