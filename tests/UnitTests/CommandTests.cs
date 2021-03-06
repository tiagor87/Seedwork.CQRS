using System;
using FluentAssertions;
using Seedwork.CQRS.UnitTests.Stubs;
using Xunit;

namespace Seedwork.CQRS.UnitTests
{
    public class CommandTests
    {
        [Fact]
        public void Given_comand_should_instatiate_with_created_at()
        {
            var command = new VoidCommandStub();
            var resultCommand = new ResultCommandStub(0);

            command.Should().NotBeNull();
            command.CreatedAt.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(1));

            resultCommand.Should().NotBeNull();
            resultCommand.CreatedAt.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(1));
        }
    }
}