using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Purse.Application.Dtos
{
    public class PurseDto
    {
        public int PurseId { get; set; }
        public float PurseBalance { get; set; }
        public string PurseKind { get; set; }
        public bool IsBlocked { get; set; }
        public int UserId { get; set; }
    }
}
