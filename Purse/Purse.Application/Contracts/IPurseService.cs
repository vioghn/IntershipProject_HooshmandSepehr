using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Purse.Domain.Entites;


namespace Purse.Application.Contracts
{
    internal interface IPurseService
    {
        public string Deposit(float amount);
        public string Withdraw(float amount);
        public List<PurseM> GetPurses();
        public float GetBalance(int PurseId);




    }
}
