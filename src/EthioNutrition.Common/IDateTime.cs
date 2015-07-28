using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EthioNutrition.Common
{
    interface IDateTime
    {
        DateTime UtcNow { get; }
    }
}
