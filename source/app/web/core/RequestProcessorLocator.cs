using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using app.web.core.commands;

namespace app.web.core {
    public class RequestProcessorLocator : IFindRequestProcessors {
        public IProcessOneRequest get_the_command_that_can_handle(IContainRequestDetails the_request){
            return new SimpleCommand();

        }
    }
}
