using System.Collections.Generic;
using app.web.core;

namespace app.web.application.catalogbrowsing
{
    public interface IFindDepartments
    {
        IEnumerable<DepartmentDisplayItem> get_the_main_departments_in_the_store();
        IEnumerable<DepartmentDisplayItem> get_the_sub_departments_in_the_department(IContainRequestDetails department);
    }

    public class DepartmentDisplayItem
    {
        public int id { get; set; }

        public string name { get; set; }

        public int parent_id { get; set; }
        
    }
}