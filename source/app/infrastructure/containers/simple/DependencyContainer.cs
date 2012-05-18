using System;

namespace app.infrastructure.containers.simple
{
    public class DependencyContainer : IFetchDependencies
    {
        IFindAFactoryForADependency factories;
        ItemCreationExceptionFactory_Behaviour exception_handing_behavior;

        public DependencyContainer(IFindAFactoryForADependency factories,
                                   ItemCreationExceptionFactory_Behaviour exception_handing_behavior)
        {
            this.factories = factories;
            this.exception_handing_behavior = exception_handing_behavior;
        }

        public Collaborator an<Collaborator>()
        {
            return (Collaborator) an(typeof(Collaborator));
        }

        public object an(Type dependency_type)
        {
            try
            {
                return factories.get_factory_that_can_create(dependency_type).create();
            }
            catch (Exception ex)
            {
                throw exception_handing_behavior(dependency_type, ex);
            }
        }
    }
}