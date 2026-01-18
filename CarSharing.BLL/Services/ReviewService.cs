using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CarSharing.BLL.DTOs.Review;
using CarSharing.BLL.Services.Interfaces;
using CarSharing.DAL.Entity;
using CarSharing.DAL.Repository;
using CarSharing.DAL.Repository.Interfaces;

namespace CarSharing.BLL.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _repo;
        private readonly IMapper _mapper;

        public ReviewService(IReviewRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ReviewDto> AddReview(CreateReviewDto dto, int reviewerId, int bookingId)
        {
            var alreadyExists = await _repo.HasUserReviewedBookingAsync(bookingId, reviewerId);

            if (alreadyExists)
            {
                
                throw new InvalidOperationException("Ви вже залишили відгук для цього бронювання.");
            }

            var review = _mapper.Map<Review>(dto);
            review.ReviewerId = reviewerId;
            review.BookingId = bookingId;

            await _repo.AddAsync(review);

            return _mapper.Map<ReviewDto>(review);

        }

        public async Task<ReviewDto> GetReviewByBookingId(int bookingId)
        {
            var review = await _repo.GetByBookingId(bookingId);

            if (review == null)
            {
                return null;
            }

           
            var reviewDto = _mapper.Map<ReviewDto>(review);

            return reviewDto;
        }

        public Task GetAllReviewsByCarId(int carId)
        {
            throw new NotImplementedException();
        }
    }
}
