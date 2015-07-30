﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EthioNutrition.Web.Api.Models
{
    public class Link
    {
        public string Href { get; set; }

        public string Rel { get; set; }
        
        public string Title { get; set; }
        
        public string Type { get; set; }
    }
}