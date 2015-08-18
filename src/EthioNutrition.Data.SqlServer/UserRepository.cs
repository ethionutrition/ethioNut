using EthioNutrition.Data.Models;
using NHibernate;
using System;
using System.Data;
namespace EthioNutrition.Data.SqlServer
{
    public class UserRepository: IUserRepository
    {
        private readonly ISession _session;
        private readonly ISqlCommandFactory _sqlCommandFactory;

        public UserRepository(ISession session, ISqlCommandFactory sqlCommandFactory)
        {
            _session = session;
            _sqlCommandFactory = sqlCommandFactory;
        }

        public void SaveUser(Guid userId, string firstname, string lastname, long profileid)
        {
            using (var command = _sqlCommandFactory.GetCommand())
            {
                command.CommandText = "dbo.SaveUser";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@userId", userId);
                command.Parameters.AddWithValue("@firstname", firstname);
                command.Parameters.AddWithValue("@lastname", lastname);
                command.Parameters.AddWithValue("@profileid", profileid);

                command.ExecuteNonQuery();
            }
        }

        public User GetUser(Guid userId)
        {
            return _session.Get<User>(userId);
        }
    }
}
