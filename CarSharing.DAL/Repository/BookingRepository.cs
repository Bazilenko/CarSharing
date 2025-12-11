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
    public class BookingRepository : GenericRepository<Booking>, IBookingRepository
    {
        public BookingRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<bool> IsCarAvailableAsync(int carId, DateTime start, DateTime end)
        {

            var hasConflict = await _dbSet.AnyAsync(b =>
                b.CarId == carId &&
                b.Status != Enums.BookingStatus.Cancelled && 
                (start < b.EndTime && end > b.StartTime) 
            );

            return !hasConflict; 
        }

        public async Task<IEnumerable<Booking>> GetBookingsByUserIdAsync(int userId)
        {
            return await _dbSet
                .Include(b => b.Car) 
                .Where(b => b.RenterId == userId)
                .OrderByDescending(b => b.StartTime)
                .ToListAsync();
        }
    }
}
