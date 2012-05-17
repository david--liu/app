using app.web.core;

namespace app.web.application.catalogbrowsing
{
    public class ViewADepartmentInTheStore : ISupportAFeature
    {
        IDisplayInformation display_engine;
        DepartmentDisplayItem department_display_item;

        public ViewADepartmentInTheStore(IDisplayInformation display_engine, DepartmentDisplayItem department_display_item)
        {
            this.display_engine = display_engine;
            this.department_display_item = department_display_item;
        }

        public void process(IContainRequestDetails request)
        {
            display_engine.display_a_department(department_display_item);
        }
    }
}