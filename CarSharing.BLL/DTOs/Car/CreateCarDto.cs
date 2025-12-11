using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSharing.BLL.DTOs
{
    public class CreateCarDto
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string LicensePlate { get; set; }
        public string VinCode { get; set; }
        public string Transmission { get; set; }
        public decimal PricePerDay { get; set; }
        public bool IsPetFriendly { get; set; }
        public string AddressText { get; set; }
        // Фото зазвичай передаються окремо через List<IFormFile> у контролері
    }
}
