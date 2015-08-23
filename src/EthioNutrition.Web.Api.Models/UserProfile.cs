using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EthioNutrition.Web.Api.Models
{
    //they represent the data that will be going back and forth between the client and your service
    public class UserProfile
    {
        public long ProfileID { get; set; }

        public DateTime? UserBirthDate { get; set; }

        public float? UserHeightInMeter { get; set; }

        public float? UserWeightInKg { get; set; }

        public float? UserBMI { get; set; }

        public List<Link> Links { get; set; }
    }
}
