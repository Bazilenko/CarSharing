using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CarSharing.BLL.DTOs.Car;
using CarSharing.DAL.Entity;
using CarSharing.DAL.Enums;

namespace CarSharing.BLL.Mappers
{
    public class CarProfile : Profile
    {
        public CarProfile()
        {
            CreateMap<CreateCarDto, Car>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => CarStatus.Active)) // За замовчуванням активна
                .ForMember(dest => dest.Transmission, opt => opt.MapFrom(src => src.Transmission)); // String -> String

            
            CreateMap<UpdateCarDto, Car>()
                .ForMember(dest => dest.Id, opt => opt.Ignore()) 
                                                                 
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

          
            CreateMap<Car, CarDto>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()))
                
                .ForMember(dest => dest.ImageUrls, opt => opt.MapFrom(src => src.Images.Select(img => img.ImageUrl).ToList()))
                
                .ForMember(dest => dest.Host, opt => opt.MapFrom(src => src.Host));
        }
    }
}
