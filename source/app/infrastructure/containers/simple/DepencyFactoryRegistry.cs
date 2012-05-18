using System;
using System.Collections.Generic;
using System.Linq;

namespace app.infrastructure.containers.simple
{
    public class DepencyFactoryRegistry : IFindAFactoryForADependency
    {
        IEnumerable<ICreateASingleDependency> factories;
        FactoryNotRegisteredExceptionFactory_Behaviour missing_factory_exception;

        public DepencyFactoryRegistry(IEnumerable<ICreateASingleDependency> factories, FactoryNotRegisteredExceptionFactory_Behaviour missing_factory_exception)
        {
            this.factories = factories;
            this.missing_factory_exception = missing_factory_exception;
        }

        public ICreateASingleDependency get_factory_that_can_create(Type type)
        {
            var result =  factories.FirstOrDefault(x => x.can_create(type));
            if (result != null) return result;
            throw missing_factory_exception(type);
        }
    }
}