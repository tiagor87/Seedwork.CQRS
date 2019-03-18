using System;
using System.Collections;
using System.Collections.Generic;
using FluentAssertions.Common;
using MediatR;
using Seedwork.CQRS.UnitTests.Stubs;

namespace Seedwork.CQRS.UnitTests.Utils
{
    public class MediatorFactory
    {
        public IMediator Create()
        {
            return new Mediator(CreateFactory);
        }

        private object CreateFactory(Type type)
        {
            if (typeof(VoidCommandStub.VoidCommandStubHandler).Implements(type))
                return new VoidCommandStub.VoidCommandStubHandler();
            if (typeof(VoidDomainExceptionCommandStub.DomainExceptionCommandStubHandler).Implements(type))
                return new VoidDomainExceptionCommandStub.DomainExceptionCommandStubHandler();
            if (typeof(VoidNonDomainExceptionCommandStub.ExceptionCommandStubHandler).Implements(type))
                return new VoidNonDomainExceptionCommandStub.ExceptionCommandStubHandler();
            if (typeof(ResultCommandStub.ResultCommandStubHandler).Implements(type))
                return new ResultCommandStub.ResultCommandStubHandler();
            if (typeof(ResultDomainExceptionCommandStub.ResultDomainExceptionCommandStubHandler).Implements(type))
                return new ResultDomainExceptionCommandStub.ResultDomainExceptionCommandStubHandler();
            if (typeof(ResultNonDomainExceptionCommandStub.ResultExceptionCommandStubHandler).Implements(type))
                return new ResultNonDomainExceptionCommandStub.ResultExceptionCommandStubHandler();

            if (type.Implements(typeof(IEnumerable)))
            {
                var listType = typeof(List<>);
                var genericTypeArgs = type.GetGenericArguments();
                return Activator.CreateInstance(listType.MakeGenericType(genericTypeArgs));
            }

            return null;
        }
    }
}