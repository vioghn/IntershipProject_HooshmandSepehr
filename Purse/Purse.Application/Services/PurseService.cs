using System;
using System.Collections.Generic;
using System.Linq;
using Purse.Application.Contracts;
using Purse.Application.Dtos;
using Purse.Domain.Entites;
using Purse.Domain.Enums;
using Purse.Infrastructure.Data;
using AutoMapper;


namespace Purse.Application.Services
{
    public class PurseService : IPurseService
    {
        private readonly PurseDbContext _dbContext;
        private readonly IMapper _mapper;

        public PurseService(PurseDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public string Deposit(int purseId, float amount)
        {
            var purse = _dbContext.Purses.FirstOrDefault(p => p.PurseId == purseId);
            if (purse == null)
                return "Purse not found.";

            var transaction = new Transaction
            {
                TransactionKind = Kind.deposit,
                TransactionStatus = Status.successful,
                TransactionTime = DateTime.Now,
                transactionValue = amount,
                Purse = purse
            };

            purse.PurseBalance += amount;

            _dbContext.Transactions.Add(transaction);
            _dbContext.SaveChanges();

            return "Deposit successful.";
        }

        // Update other methods following the same pattern
        // ...

        // Use Dtos in GetPurses method
        public List<PurseDto> GetPurses()
        {
            var purses = _dbContext.Purses.ToList();
            var purseDtos = _mapper.Map<List<PurseDto>>(purses);
            return purseDtos;
        }

        // Use Dtos in GetBalance method
        public float GetBalance(int purseId)
        {
            var purse = _dbContext.Purses.FirstOrDefault(p => p.PurseId == purseId);
            if (purse == null)
                return 0;

            return purse.PurseBalance;
        }

        // Update methods that create entities to use Dtos
        public string CreatePurse(PurseDto purseDto, int UserId)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.UserId == UserId);
            if (user == null)
                return "User not found.";

            var purse = _mapper.Map<PurseM>(purseDto);
            purse.User = user;
            purse.UserId = UserId;

            _dbContext.Purses.Add(purse);
            _dbContext.SaveChanges();
            return "Purse was added";
        }

        // Update methods that update entities to use Dtos
        public string UpdateUser(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            _dbContext.Users.Update(user);
            _dbContext.SaveChanges();
            return "User was updated";
        }

        public string Withdraw(int purseId, float amount)
        {
            var purse = _dbContext.Purses.FirstOrDefault(p => p.PurseId == purseId);
            if (purse == null)
                return "Purse not found.";

            if (purse.PurseBalance < amount)
                return "Insufficient balance.";

            // Create a new transaction
            var transaction = new Transaction
            {
                TransactionKind = Kind.withdraw,
                TransactionStatus = Status.successful,
                TransactionTime = DateTime.Now,

                transactionValue = amount,
                Purse = purse
            };

            // Update purse balance
            purse.PurseBalance -= amount;

            // Save changes to the database
            _dbContext.Transactions.Add(transaction);
            _dbContext.SaveChanges();

            return "Withdrawal successful.";
        }

        public string CreateUser(UserDto userDto, int CompanyId)
        {
            var Company = _dbContext.Companies.FirstOrDefault(u => u.CompanyId == CompanyId);
            if (Company == null)
                return "CompanyId not found";


            var user = _mapper.Map<User>(userDto);
            user.Company = Company;
            user.CompanyID = CompanyId;

            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
            return "User was added";
        }

        public string CreateCompany(CompanyDto companyDto)
        {
            var company = _mapper.Map<Company>(companyDto);
            _dbContext.Companies.Add(company);
            _dbContext.SaveChanges();
            return "Company was added";
        }

        public string Move(int sourcePurseId, int destinationPurseId, float amount)
        {
            var sourcePurse = _dbContext.Purses.FirstOrDefault(p => p.PurseId == sourcePurseId);
            var destinationPurse = _dbContext.Purses.FirstOrDefault(p => p.PurseId == destinationPurseId);

            if (sourcePurse == null || destinationPurse == null)
                return "Source or destination purse not found.";

            if (sourcePurse.PurseBalance < amount)
                return "Insufficient balance in the source purse.";

            // Create a new transaction for the source purse
            var sourceTransaction = new Transaction
            {
                TransactionKind = Kind.withdraw,
                TransactionStatus = Status.successful,
                TransactionTime = DateTime.Now,
                transactionValue = amount,
                Purse = sourcePurse
            };

            // Create a new transaction for the destination purse
            var destinationTransaction = new Transaction
            {
                TransactionKind = Kind.deposit,
                TransactionStatus = Status.successful,
                TransactionTime = DateTime.Now,
                transactionValue = amount,
                Purse = destinationPurse
            };

            // Update balances
            sourcePurse.PurseBalance -= amount;
            destinationPurse.PurseBalance += amount;

            // Save changes to the database
            _dbContext.Transactions.Add(sourceTransaction);
            _dbContext.Transactions.Add(destinationTransaction);
            _dbContext.SaveChanges();

            return "Money transfer successful.";
        }
    }
}