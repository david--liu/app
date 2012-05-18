using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Compilation;
using app.infrastructure.containers;
using app.infrastructure.containers.simple;
using app.web.application.catalogbrowsing;
using app.web.core;
using app.web.core.aspnet;
using app.web.core.stubs;

namespace app.startup
{
    public class Startup
    {
        static IDictionary<Type, ICreateASingleDependency> factories;


        private static void Add<RegisteredType>(
            IDictionary<Type, ICreateASingleDependency> factories,            
            Func<object> object_fetcher
 
            )
        {
            var type = typeof(RegisteredType);
            factories.Add(type, new DependencyFactory(new IsATypeOf(type).matches, new SimpleDependencyFactory(object_fetcher)));
        }

        public static void run()
        {
            factories = new Dictionary<Type, ICreateASingleDependency>();


            GetTheCurrentContext_Behaviour current_context = () => HttpContext.Current;
            CreatePage_Behaviour page_factory = BuildManager.CreateInstanceFromVirtualPath;

            Add<GetTheCurrentContext_Behaviour>(factories, () => current_context);
            Add<ICreateRequests>(factories, () => new StubRequestFactory());
            Add<CreateMissingRequestProcessor_Behaviour>(factories, () => StartupItems.ExceptionFactories.missing_request_processor);
            Add<IProcessWebRequests>(factories, () => new FrontController(Container.fetch.an<IFindRequestProcessors>()));
            Add<IFindRequestProcessors>(factories, () => new RequestProcessorRegistry(Container.fetch.an<IEnumerable<IProcessOneRequest>>(),
                    Container.fetch.an<CreateMissingRequestProcessor_Behaviour>()));
            Add<IDisplayInformation>(factories, () => new WebFormDisplayEngine(Container.fetch.an<IFindViews>(),
                    Container.fetch.an<GetTheCurrentContext_Behaviour>()));
            Add<CreatePage_Behaviour>(factories, () => page_factory);
            Add<IFindViews>(factories, () => new WebFormViewRegistry(Container.fetch.an<CreatePage_Behaviour>(),
                    Container.fetch.an<IFindPathsToViews>()));
            Add<IFindPathsToViews>(factories, () => new StubViewUrlRegistry());
            Add<IFetchAn<IEnumerable<DepartmentDisplayItem>>>(factories, () => new GetTheMainDepartmentsInTheStore());       
            Add<IEnumerable<IProcessOneRequest>>(factories, () => new StubSetOfProcessors());       

            var container = new DependencyContainer(new DepencyFactoryRegistry(factories.Values,
                                                               StartupItems.ExceptionFactories.factory_not_registered),
                                                               StartupItems.ExceptionFactories.item_creation_exception);
            ContainerFacadeResolution_Behaviour resolution = () => container;
            Container.facade_resolution = resolution;

        }
    }
}