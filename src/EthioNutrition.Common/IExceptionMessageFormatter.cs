using System;

namespace EthioNutrition.Common
{
    public interface IExceptionMessageFormatter
    {
        string GetEntireExceptionStack(Exception ex);
    }
}
