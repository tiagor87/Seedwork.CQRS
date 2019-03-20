using Seedwork.CQRS.Core;

namespace Seedwork.CQRS.UnitTests.Stubs
{
    public class StubException : DomainException
    {
        public StubException() : base("Exception message")
        {
        }
    }
}