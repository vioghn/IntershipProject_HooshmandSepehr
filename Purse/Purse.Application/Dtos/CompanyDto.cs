﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Purse.Application.Dtos
{
    internal class CompanyDto
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyLocation { get; set; }
        public float CompanyRate { get; set; }
        public string CompanyNo { get; set; }
    }
}
