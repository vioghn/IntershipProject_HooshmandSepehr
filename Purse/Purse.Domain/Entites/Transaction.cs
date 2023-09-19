using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Purse.Domain.Enums;

namespace Purse.Domain.Entites
{

    public class Transaction
    {
        
/*[DatabaseGenerated(DatabaseGeneratedOption.None)]*/
        public int TransactionID { get; set; }
        public  Kind TransactionKind  { get; set; }
        public Status TransactionStatus { get; set; }
        public DateTime TransactionTime { get; set; }
        public float transactionValue { get; set; }
        public int PurseId { get; set; }
        public PurseM Purse { get; set; }

    }
}
