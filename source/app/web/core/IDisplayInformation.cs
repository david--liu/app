namespace app.web.core
{
    public interface IDisplayInformation
    {
        void display<ReportModel>(ReportModel model);
        void display_a_department<ReportModel>(ReportModel model);
    }
}