using System.Collections.Generic;
using app.web.application.catalogbrowsing;
using app.web.core.aspnet;

namespace app.web.core.stubs
{
    public class StubViewUrlRegistry : IFindPathsToViews
    {
        public string get_the_url_to_the_view_that_displays<ReportModel>()
        {
            if (typeof(ReportModel) == typeof(IEnumerable<DepartmentDisplayItem>)) return browser_page("DepartmentBrowser");

            return browser_page("ProductBrowser");
        }

        string browser_page(string page_name)
        {
            return string.Format("~/views/{0}.aspx", page_name);
        }
    }
}