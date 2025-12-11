using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarSharing.DAL.Enums;

namespace CarSharing.DAL.Entity
{
    public class Booking : BaseEntity
    {
        public int CarId { get; set; }
        public Car Car { get; set; }

        public int RenterId { get; set; }
        public User Renter { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public decimal TotalPrice { get; set; }
        public BookingStatus Status { get; set; }

      
        public Payment Payment { get; set; }
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
    }
}
