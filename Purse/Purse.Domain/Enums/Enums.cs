using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Purse.Domain.Enums
{
    public enum Kind
    {
        withdraw,
        deposit,
        purchase
    }
    public enum Status
    {
        None,
        pending,
        successful,
        canceled
    }

    public enum PurseKind
    {
        Major, 
        Minor
    }
}
