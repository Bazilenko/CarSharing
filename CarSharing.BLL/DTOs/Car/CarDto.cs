using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarSharing.BLL.DTOs.User;

namespace CarSharing.BLL.DTOs.Car
{
    public class CarDto
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public decimal PricePerDay { get; set; }
        public string Transmission { get; set; }
        public bool IsPetFriendly { get; set; }
        public string Status { get; set; }
        public double LocationLat { get; set; }
        public double LocationLng { get; set; }
        public string AddressText { get; set; }

        public UserDto Host { get; set; }
        public List<string> ImageUrls { get; set; }
    }
}
