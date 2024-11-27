using Microsoft.EntityFrameworkCore;
using ServicesLab1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLab1.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly ApplicationDbContext _context;

        public TransactionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Transaction> GetAllTransactions()
        {
            return _context.Transactions.Include(b => b.Id).ToList();
        }

        public Transaction GetTransactionByID(int transactionId)
        {
            return _context.Transactions.Include(b => b.Id).FirstOrDefault(b => b.Id == transactionId);
        }

        public void AddTransaction(Transaction transaction)
        {
            _context.Transactions.Add(transaction);
            _context.SaveChanges();
        }

        public void UpdateTransaction(Transaction transaction)
        {
            _context.Transactions.Update(transaction);
            _context.SaveChanges();
        }

        public void DeleteTransaction(int transactionId)
        {
            var transaction = _context.Transactions.Find(transactionId);
            if (transaction != null)
            {
                _context.Transactions.Remove(transaction);
                _context.SaveChanges();
            }
        }
    }
}
