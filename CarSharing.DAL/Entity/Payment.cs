using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarSharing.DAL.Enums;

namespace CarSharing.DAL.Entity
{
    public class Payment : BaseEntity
    {
        public int BookingId { get; set; }
        public Booking Booking { get; set; }

        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; } 
        public string TransactionId { get; set; } 
        public PaymentStatus Status { get; set; }
    }
}
