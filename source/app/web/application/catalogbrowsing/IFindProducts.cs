using System.Collections.Generic;

namespace app.web.application.catalogbrowsing
{
    public interface IFindProducts
    {        
        IEnumerable<ProductDisplayItem> get_the_products_in(DepartmentSelection the_selected_department);
    }
}