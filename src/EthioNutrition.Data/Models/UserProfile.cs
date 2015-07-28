using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EthioNutrition.Data.Models
{
    public class UserProfile: IVersionedModelObject
    {
        public virtual long ProfileID { get; set; }
        public virtual DateTime? UserBirthDate { get; set; }
        public virtual long? UserHeightInMeter { get; set; }
        public virtual long? UserWeightInKg { get; set; }
        //user BMI should be set internally
        public virtual long? UserBMI { get;  set; }    
        public byte[] Version { get; set; }

    }

}
