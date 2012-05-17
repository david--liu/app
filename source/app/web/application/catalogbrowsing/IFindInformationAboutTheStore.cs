using System.Collections.Generic;

namespace app.web.application.catalogbrowsing
{
    public interface IFindInformationAboutTheStore
    {
        IEnumerable<DepartmentDisplayItem> get_the_main_departments_in_the_store();
        IEnumerable<DepartmentDisplayItem> get_the_departments_in(DepartmentSelection the_selected_department);
        IEnumerable<ProductDisplayItem> get_the_products_in(ViewTheProductsInADepartmentRequest request);
    }


    public class DepartmentDisplayItem
    {
        public string name { get; set; }
    }
}