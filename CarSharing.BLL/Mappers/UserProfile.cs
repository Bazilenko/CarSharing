using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CarSharing.BLL.DTOs;
using CarSharing.BLL.DTOs.User;
using CarSharing.DAL.Entity;
using CarSharing.DAL.Enums;

namespace CarSharing.BLL.Mappers
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            
            CreateMap<RegisterUserDto, User>()
               
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore())
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => UserRole.Renter)) 
                .ForMember(dest => dest.IsVerified, opt => opt.MapFrom(src => false));

            CreateMap<User, UserDto>()
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.ToString()));
        }
    }
}
