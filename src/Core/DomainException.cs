using System;

namespace Seedwork.CQRS.Core
{
    //NOSONAR
    public abstract class DomainException : Exception
    {
        protected DomainException(string message) : base(message)
        {
        }
    }
}