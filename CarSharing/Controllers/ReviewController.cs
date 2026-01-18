using System.Security.Claims;
using CarSharing.BLL.DTOs.Review;
using CarSharing.BLL.Services.Interfaces;
using CarSharing.DAL.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarSharing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] 
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewsController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpGet("booking/{bookingId}")]
        public async Task<ActionResult<ReviewDto>> GetByBookingId(int bookingId)
        {
            try
            {
                
                var review = await _reviewService.GetReviewByBookingId(bookingId);

               
                if (review == null)
                {
                    return NotFound(new { message = $"Відгук для бронювання з ID {bookingId} не знайдено." });
                }

                
                return Ok(review);
            }
            catch (Exception ex)
            {
               
                return StatusCode(500, new { message = "Внутрішня помилка сервера", details = ex.Message });
            }
        }

        [HttpPost("booking/{bookingId}")]
        public async Task<IActionResult> CreateReview([FromBody] CreateReviewDto dto)
        {
            try
            {
                var userIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (string.IsNullOrEmpty(userIdString))
                {
                    return Unauthorized("Користувач не ідентифікований.");
                }

                int reviewerId = int.Parse(userIdString);

                var result = await _reviewService.AddReview(dto, reviewerId, dto.BookingId);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
