using System.Web;
using System.Web.Compilation;
using app.web.core.stubs;

namespace app.web.core.aspnet
{
    public class WebFormViewRegistry : IFindViews
    {
        CreatePage_Behaviour page_factory;
        IFindPathsToViews url_registry;

        public WebFormViewRegistry(CreatePage_Behaviour page_factory, IFindPathsToViews url_registry)
        {
            this.page_factory = page_factory;
            this.url_registry = url_registry;
        }

        public WebFormViewRegistry():this(BuildManager.CreateInstanceFromVirtualPath,
            new StubViewUrlRegistry())
        {
        }

        public IHttpHandler find_view_that_can_display<ReportModel>(ReportModel model)
        {
            var page =
                (IDisplayA<ReportModel>) page_factory(url_registry.get_the_url_to_the_view_that_displays<ReportModel>(),
                typeof(IDisplayA<ReportModel>));
            page.model = model;
            return page;
        }
    }
}