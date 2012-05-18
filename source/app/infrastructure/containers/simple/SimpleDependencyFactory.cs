using System;

namespace app.infrastructure.containers.simple
{
    public class SimpleDependencyFactory: ICreateADependency
    {
        Func<object> factory;

        public SimpleDependencyFactory(Func<object> factory)
        {
            this.factory = factory;
        }

        public object create()
        {
            return factory();
        }
    }
}