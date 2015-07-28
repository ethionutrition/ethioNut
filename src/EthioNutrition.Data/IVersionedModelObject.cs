using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EthioNutrition.Data
{
    interface IVersionedModelObject
    {
        byte[] Version { get; set; }
    }
}
