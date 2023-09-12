using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Purse.Domain.Enums;

namespace Purse.Domain.Entites
{

    public class PurseM

    {
        public int PurseId { get; set; }
        public float PurseBalance { get; set; }
        public PurseKind PurseKind { get; set; }
        public bool IsBlocked { get; set; } 
        public int UserId { get; set; }
        public User User { get; set; }
        public IEnumerable<Transaction> Transactions { get; set; }


    }
}
