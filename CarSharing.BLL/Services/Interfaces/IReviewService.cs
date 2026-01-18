using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarSharing.BLL.DTOs.Review;

namespace CarSharing.BLL.Services.Interfaces
{
    public interface IReviewService
    {
        Task<ReviewDto> GetReviewByBookingId(int bookingId);
        Task<ReviewDto> AddReview(CreateReviewDto dto, int reviewerId, int bookingId);
        Task GetAllReviewsByCarId(int carId);

    }
}
