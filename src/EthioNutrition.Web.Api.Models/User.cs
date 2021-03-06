﻿using System;
using System.Collections.Generic;

namespace EthioNutrition.Web.Api.Models
{
    //they represent the data that will be going back and forth between the client and your service
    public class User
    {
        public Guid UserId { get; set; }
        
        public string Email { get; set; }
        
        public string Password { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public UserProfile profile { get; set; }
        
        public List<Link> Links { get; set; }
 
    }
}
