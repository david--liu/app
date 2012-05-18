using System;

namespace app.infrastructure.containers.simple
{
    public class DependencyContainer : IFetchDependencies
    {
        IFindAFactoryForADependency factories;
        readonly ItemCreationExceptionFactory_Behaviour exception_handing_behavior;

        public DependencyContainer(IFindAFactoryForADependency factories, ItemCreationExceptionFactory_Behaviour exception_handing_behavior)
        {
            this.factories = factories;
            this.exception_handing_behavior = exception_handing_behavior;
        }

        public Collaborator an<Collaborator>()
        {
            Collaborator dependency;

            try
            {
                dependency = (Collaborator) factories.get_factory_that_can_create(typeof(Collaborator)).create();
            }
            catch(Exception ex)
            {
                throw exception_handing_behavior(typeof(Collaborator),ex);
            }

            return dependency;
        }

        public object an(Type dependency_type)
        {
            throw new NotImplementedException();
        }
    }
}