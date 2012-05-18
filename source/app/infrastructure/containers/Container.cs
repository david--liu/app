using System;

namespace app.infrastructure.containers
{
    public class Container
    {
        public static ContainerFacadeResolution_Behaviour facade_resolution = delegate
        {
            throw new NotImplementedException("This is a startup configuration item");
        };

        public static IFetchDependencies fetch
        {
            get { return facade_resolution(); }
        }
    }
}