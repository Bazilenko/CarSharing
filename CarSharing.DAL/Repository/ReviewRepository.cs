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
    public class ReviewRepository : GenericRepository<Review>, IReviewRepository
    {
        public ReviewRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Review>> GetReviewsByCarIdAsync(int carId)
        {
            
            return await _dbSet
                .Include(r => r.Reviewer) 
                .Include(r => r.Booking)
                .Where(r => r.Booking.CarId == carId)
                .OrderByDescending(r => r.CreatedAt)
                .ToListAsync();
        }

        public async Task<double> GetCarAverageRatingAsync(int carId)
        {
            var ratings = _dbSet.Where(r => r.Booking.CarId == carId);

            if (!await ratings.AnyAsync())
                return 0; 

            return await ratings.AverageAsync(r => r.Rating);
        }
        public async Task<Review> GetByBookingId(int bookingId)
        {
            return await _dbSet
                .Include(r => r.Reviewer)
                .FirstOrDefaultAsync(r => r.BookingId == bookingId);
        }

        public async Task<bool> HasUserReviewedBookingAsync(int bookingId, int reviewerId)
        {
            return await _dbSet.AnyAsync(r => r.BookingId == bookingId && r.ReviewerId == reviewerId);
        }
    }
}
