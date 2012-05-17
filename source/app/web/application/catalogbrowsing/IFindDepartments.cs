using System.Collections.Generic;

namespace app.web.application.catalogbrowsing
{
    public interface IFindDepartments
    {
        IEnumerable<DepartmentDisplayItem> get_the_main_departments_in_the_store();
        IEnumerable<DepartmentDisplayItem> get_the_departments_in(DepartmentSelection the_selected_department);
    }

    public class DepartmentDisplayItem
    {
        public string name { get; set; }
    }
}