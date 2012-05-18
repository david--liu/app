using System;

namespace app.infrastructure.containers.simple
{
    public delegate Exception ItemCreationExceptionFactory_Behaviour(Type type_that_could_not_be_created,Exception inner_exception);
}