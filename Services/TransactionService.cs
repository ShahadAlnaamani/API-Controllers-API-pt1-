using ServicesLab1.Models;
using ServicesLab1.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLab1.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;

        public TransactionService(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public IEnumerable<Transaction> GetAllTransactions()
        {
            return _transactionRepository.GetAllTransactions();
        }

        public Transaction GetTransactionByID(int transactionID)
        {
            return _transactionRepository.GetTransactionByID(transactionID);
        }

        public void AddTransaction(Transaction transaction)
        {
            _transactionRepository.AddTransaction(transaction);
        }

        public void UpdateTransaction(Transaction transaction)
        {
            var existingTransaction = _transactionRepository.GetTransactionByID(transaction.Id);
            if (existingTransaction != null)
            {
                // Update properties
                existingTransaction.amount = transaction.amount;
                existingTransaction.operation = transaction.operation;
                existingTransaction.DestinationAccount = transaction.DestinationAccount;

                // Save changes to the database
                _transactionRepository.UpdateTransaction(existingTransaction);
            }
            else
            {
                throw new Exception("Transaction not found.");
            }
        }
        public void DeleteTransaction(int transactionID)
        {
            _transactionRepository.DeleteTransaction(transactionID);
        }
    }
}
