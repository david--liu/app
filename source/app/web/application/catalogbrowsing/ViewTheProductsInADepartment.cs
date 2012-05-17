using app.web.application.catalogbrowsing.stubs;
using app.web.core;
using app.web.core.aspnet;

namespace app.web.application.catalogbrowsing
{
    public class ViewTheProductsInADepartment : ISupportAFeature
    {
        IFindInformationAboutTheStore product_repository;
        IDisplayInformation display_engine;

        public ViewTheProductsInADepartment(IFindInformationAboutTheStore product_repository,
                                            IDisplayInformation display_engine)
        {
            this.product_repository = product_repository;
            this.display_engine = display_engine;
        }

        public ViewTheProductsInADepartment() : this(new StubStoreCatalog(), new WebFormDisplayEngine())
        {
        }

        public void process(IContainRequestDetails request)
        {
            display_engine.display(
                product_repository.get_the_products_in(request.map<ViewTheProductsInADepartmentRequest>()));
        }
    }
}