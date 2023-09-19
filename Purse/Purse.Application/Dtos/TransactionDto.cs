using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Purse.Application.Dtos
{
    public class TransactionDto
    {
        public int TransactionId { get; set; }
        public string TransactionKind { get; set; }
        public string TransactionStatus { get; set; }
        public DateTime TransactionTime { get; set; }
        public float TransactionValue { get; set; }
        public int PurseId { get; set; }
    }
}
