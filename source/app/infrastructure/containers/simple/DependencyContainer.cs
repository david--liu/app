namespace app.infrastructure.containers.simple
{
    public class DependencyContainer : IFetchDependencies
    {
        IFindAFactoryForADependency factories;

        public DependencyContainer(IFindAFactoryForADependency factories){
            this.factories = factories;
        }

        public Collaborator an<Collaborator>()
        {
            return (Collaborator)factories.get_factory_that_can_create(typeof(Collaborator)).create();
        }
    }
}