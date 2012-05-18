using System;

namespace app.infrastructure.containers.simple
{
    public interface IFindAFactoryForADependency
    {
        ICreateASingleDependency get_factory_that_can_create(Type type);
    }
}