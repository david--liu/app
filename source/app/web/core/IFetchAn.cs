namespace app.web.core
{
    public interface IFetchAn<ReportModel>
    {
        ReportModel run_using(IContainRequestDetails request);
    }
}