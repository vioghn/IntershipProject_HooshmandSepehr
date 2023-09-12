using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Purse.Domain.Entites
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserPhone { get; set; }
        public string UserRole { get; set; }
        public int CompanyID { get; set; }
        public Company Company { get; set; }
        public IEnumerable<PurseM> Purses { get; set; }
    }
}
