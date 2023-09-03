using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Purse.Domain.Entites
{

    internal class Transaction
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
        public int PurseId { get; set; }
        public Purse Purse { get; set; }
        



    }
}
