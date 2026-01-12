using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSharing.BLL.DTOs.Booking
{
    public class BookingDto
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public string CarTitle { get; set; } 
        public string CarImageUrl { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public decimal TotalPrice { get; set; }
        public string Status { get; set; } 

        public string OtherPartyName { get; set; }
        public string OtherPartyPhone { get; set; }
    }
}
