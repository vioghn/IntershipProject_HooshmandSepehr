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
    }
}