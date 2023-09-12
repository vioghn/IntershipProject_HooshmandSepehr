using System.Collections.Generic;
using Purse.Domain.Entites;

namespace Purse.Application.Contracts
{
    internal interface IPurseService
    {
        string Deposit(int purseId, float amount);
        string Withdraw(int purseId, float amount);
        string Move(int sourcePurseId, int destinationPurseId, float amount);
        List<PurseM> GetPurses();
        float GetBalance(int purseId);
        string UpdateUser(User user);
        string CreateCompany(Company Company);
        string CreateUser(User user, int CompanyId);
        string CreatePurse(PurseM purse, int UserId);



    }
}