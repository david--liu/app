using System;

namespace app.infrastructure.containers.simple
{
    public delegate Exception FactoryNotRegisteredExceptionFactory_Behaviour(Type type_that_has_no_factory);
}