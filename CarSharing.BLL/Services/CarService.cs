using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CarSharing.BLL.DTOs.Car;
using CarSharing.BLL.Services.Interfaces;
using CarSharing.DAL.Entity;
using CarSharing.DAL.Repository.Interfaces;
using Microsoft.AspNetCore.Http;

namespace CarSharing.BLL.Services
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;
        private readonly IGenericRepository<CarImage> _imageRepository;
        private readonly IFileService _fileService;
        private readonly IMapper _mapper;

        public CarService(ICarRepository carRepository, IGenericRepository<CarImage> imageRepository, IFileService fileService, IMapper mapper)
        {
            _carRepository = carRepository;
            _imageRepository = imageRepository;
            _fileService = fileService;
            _mapper = mapper;
        }

        public async Task CreateCarAsync(CreateCarDto dto, List<IFormFile> images, int hostId)
        {
            var car = _mapper.Map<Car>(dto);
            car.HostId = hostId;

            await _carRepository.AddAsync(car);

            if (images != null && images.Any())
            {
                foreach (var image in images)
                {
                    var path = await _fileService.SaveFileAsync(image, "cars");
                    await _imageRepository.AddAsync(new CarImage
                    {
                        CarId = car.Id,
                        ImageUrl = path,
                        IsMain = (images.IndexOf(image) == 0) 
                    });
                }
            }
        }

        

        public async Task<CarDto> GetByIdAsync(int id)
        {
            var car = await _carRepository.GetCarWithDetailsAsync(id);
            if (car == null) throw new Exception("Авто не знайдено");

            return _mapper.Map<CarDto>(car);
        }

        public async Task<IEnumerable<CarDto>> GetAllAsync()
        {
            var cars = await _carRepository.GetAllCars();
            return _mapper.Map<IEnumerable<CarDto>>(cars);
        }
    }
}
