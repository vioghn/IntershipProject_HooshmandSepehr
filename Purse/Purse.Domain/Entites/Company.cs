﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Purse.Domain.Entites
{
    public class Company

    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        /*[Key] */
        public int CompanyId { get; set; }
        public string CompanyName { get; set; } 
        public string CompanyLocation { get; set; } 
        public float CompanyRate  {get; set; } 
        public string CompinyNo { get; set;
        }
        public IEnumerable<User> Users { get; set; }




    }
}
