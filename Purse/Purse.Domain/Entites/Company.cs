﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Purse.Domain.Entites
{
    internal class Company
    {
        [Key] 
        public int CompanyId { get; set; }
        public string CompanyName { get; set; } 
        public string CompanyLocation { get; set; } 
        public float CompanyRate  {get; set; } 
        public string CompinyNo { get; set;
        }


        

    }
}