using System.Security.Claims;
using CarSharing.BLL.DTOs.Car;
using CarSharing.BLL.Services.Interfaces;
using CarSharing.DAL.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarSharing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        // GET: api/cars
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var cars = await _carService.GetAllAsync();
            return Ok(cars);
        }

        // GET: api/cars/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var car = await _carService.GetByIdAsync(id);
                return Ok(car);
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        // POST: api/cars
        [HttpPost]
        [Authorize] 
        public async Task<IActionResult> Create([FromForm] CreateCarDto dto, [FromForm] List<IFormFile> images)
        {
            try
            {
                
                var userIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (string.IsNullOrEmpty(userIdString)) return Unauthorized();

                int hostId = int.Parse(userIdString);

                await _carService.CreateCarAsync(dto, images, hostId);
                return Ok(new { message = "Авто успішно додано!" });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    message = ex.Message,
                    innerMessage = ex.InnerException?.Message 
                });
            }
        }
    }
}
