using System.Collections.Generic;
using Purse.Domain.Entites;
using Purse.Application.Dtos;

namespace Purse.Application.Contracts
{
    public interface IPurseService
    {
        string Deposit(int purseId, float amount);
        string Withdraw(int purseId, float amount);
        string Move(int sourcePurseId, int destinationPurseId, float amount);
        List<PurseDto> GetPurses(); //Done
        float GetBalance(int purseId); //Done
        string UpdateUser(UserDto user); //Done
        string CreateCompany(CompanyDto Company); //Done
        string CreateUser(UserDto user, int CompanyId); //Done
        string CreatePurse(PurseDto purse, int UserId); //Done



    }
}