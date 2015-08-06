using NHibernate;
using System;

namespace EthioNutrition.Web.Common
{
    public interface ICurrentSessionContextAdapter
    {
        bool HasBind(ISessionFactory sessionFactory);
        ISession Unbind(ISessionFactory sessionFactory);
    }
}
