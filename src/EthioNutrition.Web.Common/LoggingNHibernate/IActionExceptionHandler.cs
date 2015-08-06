using System;
using System.Web.Http.Filters;

namespace EthioNutrition.Web.Common.LoggingNHibernate
{
    public interface IActionExceptionHandler
    {
        void HandleException(HttpActionExecutedContext filterContext);
    }
}
