using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Purse.Application.Dtos
{
    public class VoacherDto
    {
        public int VoacherId { get; set; }
        public int PurseSourceId { get; set; }
        public int PurseDestinationId { get; set; }
        public DateTime VoacherTime { get; set; }
        public string VoacherStatus { get; set; }
        public float VoacherValue { get; set; }
    }
}
