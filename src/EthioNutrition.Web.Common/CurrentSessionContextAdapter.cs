using NHibernate;
using NHibernate.Context;
using System;

namespace EthioNutrition.Web.Common
{
    public class CurrentSessionContextAdapter: ICurrentSessionContextAdapter
    {
        public bool HasBind(ISessionFactory sessionFactory)
        {
            return CurrentSessionContext.HasBind(sessionFactory);
        }

        public ISession Unbind(NHibernate.ISessionFactory sessionFactory)
        {
            return CurrentSessionContext.Unbind(sessionFactory);
        }
    }
}
