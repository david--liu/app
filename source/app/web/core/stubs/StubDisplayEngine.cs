﻿using System.Web;

namespace app.web.core.stubs
{
    public class StubDisplayEngine : IDisplayInformation
    {
        public void display<ReportModel>(ReportModel model)
        {
            HttpContext.Current.Items.Add("blah", model);
            HttpContext.Current.Server.Transfer("~/views/DepartmentBrowser.aspx");
        }

        public void display_a_department<ReportModel>(ReportModel model)
        {
            throw new System.NotImplementedException();
        }
    }
}