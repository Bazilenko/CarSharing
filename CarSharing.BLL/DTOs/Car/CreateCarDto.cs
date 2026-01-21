using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarSharing.DAL.Enums;

namespace CarSharing.BLL.DTOs.Car
{
    public class CreateCarDto
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string LicensePlate { get; set; }
        public string VinCode { get; set; }


        public string Transmission { get; set; }
        public string FuelType { get; set; }
        public string BodyType { get; set; }
        public bool IsPetFriendly { get; set; }

        public decimal PricePerDay { get; set; }

        public double LocationLat { get; set; }
        public double LocationLng { get; set; }
        public string AddressText { get; set; }

    }
}
