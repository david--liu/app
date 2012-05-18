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

        public static void run()
        {
            factories = new Dictionary<Type, ICreateASingleDependency>();


            GetTheCurrentContext_Behaviour current_context = () => HttpContext.Current;
            CreatePage_Behaviour page_factory = BuildManager.CreateInstanceFromVirtualPath;

            factories.Add(typeof(GetTheCurrentContext_Behaviour), new DependencyFactory(new IsATypeOf(typeof(GetTheCurrentContext_Behaviour)).matches,
                new SimpleDependencyFactory(() => current_context)));

            factories.Add(typeof(ICreateRequests), new DependencyFactory(new IsATypeOf(typeof(ICreateRequests)).matches,
                new SimpleDependencyFactory(() => new StubRequestFactory())));

            factories.Add(typeof(CreateMissingRequestProcessor_Behaviour), new DependencyFactory(new IsATypeOf(typeof(CreateMissingRequestProcessor_Behaviour)).matches,
                new SimpleDependencyFactory(() => StartupItems.ExceptionFactories.missing_request_processor)));

            factories.Add(typeof(IProcessWebRequests), new DependencyFactory(new IsATypeOf(typeof(IProcessWebRequests)).matches,
                new SimpleDependencyFactory(() => new FrontController(Container.fetch.an<IFindRequestProcessors>()))));

            factories.Add(typeof(IFindRequestProcessors), new DependencyFactory(new IsATypeOf(typeof(IFindRequestProcessors)).matches,
                new SimpleDependencyFactory(() => new RequestProcessorRegistry(Container.fetch.an<IEnumerable<IProcessOneRequest>>(),
                    Container.fetch.an<CreateMissingRequestProcessor_Behaviour>()))));

            factories.Add(typeof(IDisplayInformation), new DependencyFactory(new IsATypeOf(typeof(IDisplayInformation)).matches,
                new SimpleDependencyFactory(() => new WebFormDisplayEngine(Container.fetch.an<IFindViews>(),
                    Container.fetch.an<GetTheCurrentContext_Behaviour>()))));

            factories.Add(typeof(CreatePage_Behaviour), new DependencyFactory(new IsATypeOf(typeof(CreatePage_Behaviour)).matches,
                new SimpleDependencyFactory(() => page_factory)));

            factories.Add(typeof(IFindViews), new DependencyFactory(new IsATypeOf(typeof(IFindViews)).matches,
                new SimpleDependencyFactory(() => new WebFormViewRegistry(Container.fetch.an<CreatePage_Behaviour>(),
                    Container.fetch.an<IFindPathsToViews>()))));

            factories.Add(typeof(IFindPathsToViews),
                          new DependencyFactory(new IsATypeOf(typeof(IFindPathsToViews)).matches,
                                                new SimpleDependencyFactory(() => new StubViewUrlRegistry())));

            factories.Add(typeof(IFetchAn<IEnumerable<DepartmentDisplayItem>>),
                          new DependencyFactory(new IsATypeOf(typeof(IFetchAn<IEnumerable<DepartmentDisplayItem>>)).matches,
                                                new SimpleDependencyFactory(() => new GetTheMainDepartmentsInTheStore())));

            factories.Add(typeof(IEnumerable<IProcessOneRequest>),
                          new DependencyFactory(new IsATypeOf(typeof(IEnumerable<IProcessOneRequest>)).matches,
                                                new SimpleDependencyFactory(() => new StubSetOfProcessors())));

            var container = new DependencyContainer(new DepencyFactoryRegistry(factories.Values,
                                                               StartupItems.ExceptionFactories.factory_not_registered),
                                                               StartupItems.ExceptionFactories.item_creation_exception);
            ContainerFacadeResolution_Behaviour resolution = () => container;
            Container.facade_resolution = resolution;

        }
    }
}