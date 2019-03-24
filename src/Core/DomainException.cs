using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace Seedwork.CQRS.Core
{
    [Serializable]
    public abstract class DomainException : Exception
    {
        protected DomainException(string message) : base(message)
        {
        }

        [ExcludeFromCodeCoverage]
        private DomainException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        [ExcludeFromCodeCoverage]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }
    }
}