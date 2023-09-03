﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Purse.Domain.Entites
{

    public class Transaction
    {
        public enum Kind
        {
            withdraw,
            deposit,
            move,
            purchase

        }
        public int TransactionID { get; set; }
        public  Kind TransactionKind  { get; set; }

        public DateTime TransactionTime { get; set; }
        public int PurseId { get; set; }
        public PurseM Purse { get; set; }
        



    }
}
