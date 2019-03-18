using System;
using System.Threading.Tasks;
using FluentAssertions;
using MediatR;
using Seedwork.CQRS.UnitTests.Stubs;
using Seedwork.CQRS.UnitTests.Utils;
using Xunit;

namespace Seedwork.CQRS.UnitTests
{
    public class CommandHandlerTests : IClassFixture<MediatorFactory>
    {
        public CommandHandlerTests(MediatorFactory mediatorFactory)
        {
            _mediator = mediatorFactory.Create();
        }

        private readonly IMediator _mediator;

        [Theory(DisplayName = "GIVEN command, WHEN successful, SHOULD return value")]
        [InlineData("Value")]
        [InlineData(1)]
        [InlineData('V')]
        public async Task Given_command_when_successful_should_return_value(object value)
        {
            var command = new ResultCommandStub(value);

            var result = await _mediator.Send(command);

            result.Successful.Should().BeTrue();
            result.As<object>().Should().Be(value);
        }

        [Fact(DisplayName = @"GIVEN command, WHEN throw domain exception, SHOULD return failure result")]
        public async Task Given_command_when_throw_domain_exception_should_return_failure_result()
        {
            var command = new ResultDomainExceptionCommandStub();

            var result = await _mediator.Send(command);

            result.Failure.Should().BeTrue();
        }

        [Fact(DisplayName = @"GIVEN command, WHEN throw non domain exception, SHOULD throw")]
        public async Task Given_command_when_throw_non_domain_exception_should_throw()
        {
            var command = new ResultNonDomainExceptionCommandStub();

            await _mediator
                .Awaiting(x => x.Send(command))
                .Should()
                .ThrowAsync<Exception>();
        }

        [Fact(DisplayName = @"GIVEN void_command, SHOULD return successful result")]
        public async Task Given_void_command_should_return_successful_result()
        {
            var command = new VoidCommandStub();

            var result = await _mediator.Send(command);

            result.Successful.Should().BeTrue();
        }

        [Fact(DisplayName = @"GIVEN void_command, WHEN throw domain exception, SHOULD return failure result")]
        public async Task Given_void_command_when_throw_domain_exception_should_return_failure_result()
        {
            var command = new VoidDomainExceptionCommandStub();

            var result = await _mediator.Send(command);

            result.Failure.Should().BeTrue();
        }

        [Fact(DisplayName = @"GIVEN void_command, WHEN throw non domain exception, SHOULD throw")]
        public async Task Given_void_command_when_throw_non_domain_exception_should_throw()
        {
            var command = new VoidNonDomainExceptionCommandStub();

            await _mediator
                .Awaiting(x => x.Send(command))
                .Should()
                .ThrowAsync<Exception>();
        }
    }
}