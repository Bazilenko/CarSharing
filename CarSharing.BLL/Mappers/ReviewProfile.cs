using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CarSharing.BLL.DTOs.Review;
using CarSharing.DAL.Entity;

namespace CarSharing.BLL.Mappers
{
    public class ReviewProfile : Profile
    {
        public ReviewProfile()
        {
            CreateMap<CreateReviewDto, Review>();

            CreateMap<Review, ReviewDto>()

                .ForMember(dest => dest.ReviewerName, opt => opt.MapFrom(src => $"{src.Reviewer.FirstName} {src.Reviewer.LastName}"));
                
        }
    }
}
