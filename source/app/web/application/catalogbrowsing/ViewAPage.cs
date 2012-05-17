using System;
using app.web.core;
using app.web.core.aspnet;

namespace app.web.application.catalogbrowsing
{

    public class ViewAPage<ReportModel> : ISupportAFeature
    {
        Func<IContainRequestDetails, ReportModel> accessor;
        IDisplayInformation display_engine;



        public ViewAPage(Func<IContainRequestDetails, ReportModel> accessor) : this(accessor , new WebFormDisplayEngine())
        {
        }

        public ViewAPage(Func<IContainRequestDetails, ReportModel> accessor, IDisplayInformation displayEngine)
        {
            this.accessor = accessor;
            display_engine = displayEngine;
        }

        public void process(IContainRequestDetails request)
        {
            display_engine.display(accessor(request));
        }

    
    }
}