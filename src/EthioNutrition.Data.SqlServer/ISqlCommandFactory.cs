using System.Data.SqlClient;

namespace EthioNutrition.Data.SqlServer
{
    public interface ISqlCommandFactory
    {
        SqlCommand GetCommand();
    }
}
