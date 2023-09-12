using System.Collections.Generic;
using Purse.Domain.Entites;

namespace Purse.Application.Contracts
{
    public interface IPurseService
    {
        string Deposit(int purseId, float amount);
        string Withdraw(int purseId, float amount);
        string Move(int sourcePurseId, int destinationPurseId, float amount);
        List<PurseM> GetPurses(); //Done
        float GetBalance(int purseId); //Done
        string UpdateUser(User user); //Done
        string CreateCompany(Company Company); //Done
        string CreateUser(User user, int CompanyId); //Done
        string CreatePurse(PurseM purse, int UserId); //Done



    }
}