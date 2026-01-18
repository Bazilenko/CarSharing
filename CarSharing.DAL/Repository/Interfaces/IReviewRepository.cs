using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarSharing.DAL.Entity;

namespace CarSharing.DAL.Repository.Interfaces
{
    public interface IReviewRepository : IGenericRepository<Review>
    {
       
        Task<IEnumerable<Review>> GetReviewsByCarIdAsync(int carId);
        Task<Review> GetByBookingId(int bookingId);



        Task<double> GetCarAverageRatingAsync(int carId);

        Task<bool> HasUserReviewedBookingAsync(int bookingId, int reviewerId);
    }
}
