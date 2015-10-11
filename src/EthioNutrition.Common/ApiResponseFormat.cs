

namespace EthioNutrition.Common
{
    public class ApiResponseFormat: IApiResponseFormat
    {
        public string Json
        {
            get { return "application/json"; }
        }
    }
}
