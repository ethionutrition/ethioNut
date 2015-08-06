using System;
using System.Web.Http.Filters;

namespace EthioNutrition.Web.Common.LoggingNHibernate
{
    public interface IActionTransactionHelper
    {
        void BeginTransaction();
        void EndTransaction(HttpActionExecutedContext filterContext);
        void CloseSession();
    }
}
