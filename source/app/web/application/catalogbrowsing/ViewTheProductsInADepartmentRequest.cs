using System;

namespace app.web.application.catalogbrowsing
{
    public class ViewTheProductsInADepartmentRequest
    {
        public string name { get; set; }         
        public Guid department_id { get; set; }         
    }
}