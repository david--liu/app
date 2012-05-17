using System.Collections.Generic;
using System.Linq;

namespace app.web.application.catalogbrowsing.stubs
{
    public class StubDepartmentRepository : IFindDepartments
    {
        public IEnumerable<DepartmentDisplayItem> get_the_main_departments_in_the_store()
        {
            return Enumerable.Range(1, 100).Select(x => new DepartmentDisplayItem{name = x.ToString("Department 0")});
        }

        public IEnumerable<DepartmentDisplayItem> get_the_departments_in(DepartmentSelection the_selected_department)
        {
            return Enumerable.Range(1, 100).Select(x => new DepartmentDisplayItem{name = x.ToString("Sub Department 0")});
        }
    }
}
