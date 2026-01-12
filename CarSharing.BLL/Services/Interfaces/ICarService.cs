using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarSharing.BLL.DTOs.Car;
using Microsoft.AspNetCore.Http;

namespace CarSharing.BLL.Services.Interfaces
{
    public interface ICarService
    {
        Task CreateCarAsync(CreateCarDto dto, List<IFormFile> images, int hostId);
        Task<CarDto> GetByIdAsync(int id);
        Task<IEnumerable<CarDto>> GetAllAsync();
    }
}
