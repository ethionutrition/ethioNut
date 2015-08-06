using log4net;
using System;
using System.Web.Http.Controllers;

namespace EthioNutrition.Web.Common.LoggingNHibernate
{
    public class ActionLogHelper: IActionLogHelper
    {
        public const string EnteringText = "ENTERING";
        public const string ExitingText = "EXITING";
        public const string LogTextFormatString = "{0} {1}::{2}";

        private ILog _logger;

        public ActionLogHelper(ILog logger)
        {
            _logger = logger;
        }
        public void LogEntry(HttpActionDescriptor actionDecriptor)
        {
            LogAction(actionDecriptor, EnteringText);
        }

        public void LogExit(HttpActionDescriptor actionDescriptor)
        {
            LogAction(actionDescriptor, ExitingText);
        }

        public virtual void LogAction(HttpActionDescriptor actionDescriptor, string prefix)
        {
            _logger.DebugFormat(
                LogTextFormatString,
                prefix,
                actionDescriptor.ControllerDescriptor.ControllerName,
                actionDescriptor.ActionName);
        }
    }
}
