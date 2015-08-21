using System;

namespace EthioNutrition.Data.Models
{
    //Models used for internal purpose only, used by NHibernate
    public class UserProfile: IVersionedModelObject
    {
        public virtual long ProfileID { get; set; }
        
        public virtual DateTime ? UserBirthDate { get; set; }
        
        public virtual long ? UserHeightInMeter { get; set; }
        
        public virtual long ? UserWeightInKg { get; set; }
        
        //user BMI should be set internally
        public virtual long UserBMI { get;  set; }    
        
        public virtual byte[] Version { get; set; }

    }

}
