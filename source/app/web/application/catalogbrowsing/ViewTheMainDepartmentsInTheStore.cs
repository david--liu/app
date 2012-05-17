using app.web.application.catalogbrowsing.stubs;
using app.web.core;
using app.web.core.stubs;

namespace app.web.application.catalogbrowsing
{
    public class ViewTheMainDepartmentsInTheStore : ISupportAFeature
    {
        IFindInformationAboutTheStore store_catalog;
        IDisplayInformation display_engine;

        public ViewTheMainDepartmentsInTheStore(IFindInformationAboutTheStore store_catalog,
                                                IDisplayInformation display_engine)
        {
            this.store_catalog = store_catalog;
            this.display_engine = display_engine;
        }

        public ViewTheMainDepartmentsInTheStore():this(new StubStoreCatalog(),
            new StubDisplayEngine())
        {
        }

        public void process(IContainRequestDetails request)
        {
            display_engine.display(store_catalog.get_the_main_departments_in_the_store());
        }
    }
}