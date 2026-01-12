using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarSharing.DAL.Context;
using CarSharing.DAL.Entity;
using CarSharing.DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CarSharing.DAL.Repository
{
    public class PaymentRepository : GenericRepository<Payment>, IPaymentRepository
    {
        public PaymentRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Payment?> GetByBookingIdAsync(int bookingId)
        {
            return await _dbSet.FirstOrDefaultAsync(p => p.BookingId == bookingId);
        }

        public async Task<Payment?> GetByTransactionIdAsync(string transactionId)
        {
            return await _dbSet.FirstOrDefaultAsync(p => p.TransactionId == transactionId);
        }
    }
}
