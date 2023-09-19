using Purse.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Purse.Domain.Entites
{
    public class Voacher
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int VoacherId { get; set; }
        public int PurseSourceId { get; set; }
        public int PurseDestinationID { get; set; }
        public DateTime VoacherTime { get; set; }
        public Status VoacherStatus { get; set; }
        public float VoacherValue { get; set; }
        public virtual PurseM SourcePurse { get; set; }
        public virtual PurseM DestinationPurse { get; set; }

    }
}
