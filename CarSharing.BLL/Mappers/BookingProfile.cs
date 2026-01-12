using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CarSharing.BLL.DTOs.Booking;
using CarSharing.DAL.Entity;
using CarSharing.DAL.Enums;

namespace CarSharing.BLL.Mappers
{
    public class BookingProfile : Profile
    {
        public BookingProfile()
        {
            
            CreateMap<CreateBookingDto, Booking>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => BookingStatus.Pending)); 

            
            CreateMap<Booking, BookingDto>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()))

                
                .ForMember(dest => dest.CarTitle, opt => opt.MapFrom(src => $"{src.Car.Make} {src.Car.Model}"))

                
                .ForMember(dest => dest.CarImageUrl, opt => opt.MapFrom(src =>
                    src.Car.Images.FirstOrDefault(i => i.IsMain) != null
                        ? src.Car.Images.FirstOrDefault(i => i.IsMain).ImageUrl
                        : src.Car.Images.FirstOrDefault().ImageUrl));
        }
    }
}
