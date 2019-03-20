using System;

namespace Seedwork.CQRS.Core
{
    public abstract class DomainException : Exception
    {
        protected DomainException(string message) : base(message)
        {
        }
    }
}