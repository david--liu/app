using System.Collections.Generic;

namespace app.web.application.catalogbrowsing
{
    public interface IFindDepartments
    {
        IEnumerable<DepartmentDisplayItem> get_the_main_departments_in_the_store();
    }

    public class DepartmentDisplayItem
    {
        public string name { get; set; }
    }
}