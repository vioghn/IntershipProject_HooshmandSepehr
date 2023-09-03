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
<<<<<<< HEAD
=======

>>>>>>> aa90671b96d42de1d8e6ef26b1f1aec034a16507
        public int PurseId { get; set; }
        public PurseM Purse { get; set; }
     
            
        
    }
}
