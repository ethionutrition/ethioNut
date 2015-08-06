using System;
using System.Web.Http.Controllers;

namespace EthioNutrition.Web.Common.LoggingNHibernate
{
    public interface IActionLogHelper
    {
        void LogEntry(HttpActionDescriptor actionDecriptor);
        void LogExit(HttpActionDescriptor actionDescriptor);
        void LogAction(HttpActionDescriptor actionDescriptor, string prefix);
    }
}
