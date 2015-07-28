using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EthioNutrition.Common;
namespace EthioNutrition.Data.Models
{
    //Models used for internal purpose only, used by NHibernate
    public class User:IVersionedModelObject
    {
        public virtual Guid UserId { get; set; }
        public virtual string Email { get; set; }
        public virtual string UserName { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual DateTime DateCreated { get; set; }
        public virtual byte[] Version{get;set;}
        public virtual UserProfile profile { get; set; }       
    }
}

