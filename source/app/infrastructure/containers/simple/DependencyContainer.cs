namespace app.infrastructure.containers.simple
{
    public class DependencyContainer : IFetchDependencies
    {
        IFindAFactoryForADependency factory_finder;

        public DependencyContainer(IFindAFactoryForADependency factoryFinder){
            factory_finder = factoryFinder;
        }

        public Collaborator an<Collaborator>()
        {
            return (Collaborator)factory_finder.get_factory_that_can_create(typeof(Collaborator)).create();
        }
    }
}