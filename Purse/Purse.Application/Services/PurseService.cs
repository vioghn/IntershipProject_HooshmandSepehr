using System;
using System.Collections.Generic;
using System.Linq;
using Purse.Application.Contracts;
using Purse.Domain.Entites;
using Purse.Domain.Enums;
using Purse.Infrastructure.Data;


namespace Purse.Application.Services
{
    internal class PurseService : IPurseService
    {
        private readonly PurseDbContext _dbContext;

        public PurseService(PurseDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public string Deposit(int purseId, float amount)
        {
            var purse = _dbContext.Purses.FirstOrDefault(p => p.PurseId == purseId);
            if (purse == null)
                return "Purse not found.";

            // Create a new transaction
            var transaction = new Transaction
            {
                TransactionKind = Kind.deposit,
                TransactionStatus = Status.successful,
                TransactionTime = DateTime.Now,
                transactionValue = amount,
                Purse = purse
            };

            // Update purse balance
            purse.PurseBalance += amount;

            // Save changes to the database
            _dbContext.Transactions.Add(transaction);
            _dbContext.SaveChanges();

            return "Deposit successful.";
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

        public List<PurseM> GetPurses()
        {
            return _dbContext.Purses.ToList();
        }

        public float GetBalance(int purseId)
        {
            var purse = _dbContext.Purses.FirstOrDefault(p => p.PurseId == purseId);
            if (purse == null)
                return 0;

            return purse.PurseBalance;
        }
    }
}