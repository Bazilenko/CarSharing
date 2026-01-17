using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarSharing.BLL.DTOs.Booking;

namespace CarSharing.BLL.Services.Interfaces
{
    public interface IBookingService
    {
        Task<BookingDto> CreateBookingAsync(CreateBookingDto dto, int renterId);
        Task<IEnumerable<BookingDto>> GetMyBookingsAsync(int userId);
        Task<BookingDto> CancelBooking(int bookingId);
    }
}
