using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSharing.BLL.DTOs
{
    public class BookingDto
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public string CarTitle { get; set; } // "Toyota Camry 2020"
        public string CarImageUrl { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public decimal TotalPrice { get; set; }
        public string Status { get; set; } // "Pending", "Active", "Completed"

        // Контакти іншої сторони (показуємо тільки якщо статус Confirmed)
        public string OtherPartyName { get; set; }
        public string OtherPartyPhone { get; set; }
    }
}
