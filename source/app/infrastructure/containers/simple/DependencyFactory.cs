using System;

namespace app.infrastructure.containers.simple
{
    public class DependencyFactory : ICreateASingleDependency
    {
        Predicate<Type> type_criteria;
        ICreateADependency real_factory;

        public DependencyFactory(Predicate<Type> type_criteria, ICreateADependency real_factory)
        {
            this.type_criteria = type_criteria;
            this.real_factory = real_factory;
        }

        public object create()
        {
            return real_factory.create();
        }

        public bool can_create(Type type)
        {
            return type_criteria(type);
        }
    }
}