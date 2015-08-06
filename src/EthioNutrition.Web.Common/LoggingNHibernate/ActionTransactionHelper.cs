using NHibernate;
using System;
using System.Web.Http.Filters;
namespace EthioNutrition.Web.Common.LoggingNHibernate
{
   public  class ActionTransactionHelper: IActionTransactionHelper
    {
       private readonly ISessionFactory _sessionFactory;
       private readonly ICurrentSessionContextAdapter _currentSessionContextAdapter;

       public ActionTransactionHelper(ISessionFactory sessionFactory, ICurrentSessionContextAdapter currentSessionContext)
       {
           _sessionFactory = sessionFactory;
           _currentSessionContextAdapter = currentSessionContext;
       }
        public void BeginTransaction()
        {
            var session = _sessionFactory.GetCurrentSession();
            if (session != null)
            {
                session.BeginTransaction();
            }
        }

        public bool TransactionHandled { get; private set; }

        public void EndTransaction(HttpActionExecutedContext filterContext)
        {
            var session = _sessionFactory.GetCurrentSession();
            if (session==null) return;
            
            if (!session.Transaction.IsActive) return;

            if (filterContext.Exception == null)
            {
                session.Flush();
                session.Transaction.Commit();
            }
            else
            {
                session.Transaction.Rollback();
            }
            TransactionHandled = true;
        }

        public bool SessionClosed { get; private set; }

        public void CloseSession()
        {
            if (_currentSessionContextAdapter.HasBind(_sessionFactory))
            {
                var session = _sessionFactory.GetCurrentSession();
                session.Close();
                session.Dispose();
                _currentSessionContextAdapter.Unbind(_sessionFactory);

                SessionClosed = true;
            }
        }
    }
}
