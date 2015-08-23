using System;

namespace EthioNutrition.Data.Models
{
    //Models used for internal purpose only, used by NHibernate
    public class UserProfile: IVersionedModelObject
    {
        public virtual long ProfileID { get; set; }
        
        public virtual DateTime ? UserBirthDate { get; set; }

        public virtual float? UserHeightInMeter { get; set; }

        public virtual float? UserWeightInKg { get; set; }
        
        public virtual float? UserBMI { get;  set; }    
        
        public virtual byte[] Version { get; set; }

    }

}
