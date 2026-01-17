using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CarSharing.BLL.DTOs.Booking;
using CarSharing.BLL.Exceptions;
using CarSharing.BLL.Services.Interfaces;
using CarSharing.DAL.Entity;
using CarSharing.DAL.Repository.Interfaces;

namespace CarSharing.BLL.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;

        public BookingService(IBookingRepository bookingRepository, ICarRepository carRepository, IMapper mapper)
        {
            _bookingRepository = bookingRepository;
            _carRepository = carRepository;
            _mapper = mapper;
        }


        public async Task<BookingDto> CreateBookingAsync(CreateBookingDto dto, int renterId)
        {
            var car = await _carRepository.GetByIdAsync(dto.CarId);
            if (car == null) throw new Exception("Авто не знайдено");

            var isAvailable = await _bookingRepository.IsCarAvailableAsync(dto.CarId, dto.StartTime, dto.EndTime);
            if (!isAvailable)
                throw new Exception("На жаль, авто зайняте на ці дати.");

            var days = (dto.EndTime - dto.StartTime).TotalDays;
            
            var totalDays = (int)Math.Ceiling(days);
            if (totalDays < 1) totalDays = 1;

            var totalPrice = totalDays * car.PricePerDay;

            
            var booking = _mapper.Map<Booking>(dto);
            booking.RenterId = renterId;
            booking.TotalPrice = totalPrice;

            await _bookingRepository.AddAsync(booking);

            booking.Car = car; 
            return _mapper.Map<BookingDto>(booking);
        }

        public async Task<IEnumerable<BookingDto>> GetMyBookingsAsync(int userId)
        {
            var bookings = await _bookingRepository.GetBookingsByUserIdAsync(userId);
            return _mapper.Map<IEnumerable<BookingDto>>(bookings);
        }

        public async Task<BookingDto> CancelBooking(int bookingId)
        {
            var booking = await _bookingRepository.GetByIdAsync(bookingId);

            if (booking == null)
                throw new NotFoundException($"Booking not found!");
            await _bookingRepository.DeleteAsync(booking);

            return _mapper.Map<BookingDto>(booking);

        }
    }
}
