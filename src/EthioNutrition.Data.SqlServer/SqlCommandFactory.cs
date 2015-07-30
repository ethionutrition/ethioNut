using System.Data;
using System.Data.SqlClient;
using NHibernate;

namespace EthioNutrition.Data.SqlServer
{
    public class SqlCommandFactory: ISqlCommandFactory
    {
        private readonly ISession _session;
        public SqlCommandFactory(ISession session)
        {
            _session = session;
        }
        public SqlCommand GetCommand()
        {
            var connection = GetOpenConection();
            var command = (SqlCommand)connection.CreateCommand();
            if (_session.Transaction != null)
            {
                _session.Transaction.Enlist(command);
            }
            return command;
        }

        private IDbConnection GetOpenConection()
        {
            var connection = _session.Connection;
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            return connection;
        }

    }
}
