using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarSharing.DAL.Entity;

namespace CarSharing.DAL.Repository.Interfaces
{
    public interface IBookingRepository : IGenericRepository<Booking>
    {
        
        Task<bool> IsCarAvailableAsync(int carId, DateTime start, DateTime end);

        Task<IEnumerable<Booking>> GetBookingsByUserIdAsync(int userId);
    }
}
