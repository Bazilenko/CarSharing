using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSharing.BLL.DTOs.Car
{
    public class CarSearchDto
    {
        public string? City { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public string? Transmission { get; set; } 
        public bool? IsPetFriendly { get; set; }


        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
