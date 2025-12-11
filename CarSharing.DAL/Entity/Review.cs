using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSharing.DAL.Entity
{
    
        public class Review : BaseEntity
        {
            public int BookingId { get; set; }
            public Booking Booking { get; set; }

            public int ReviewerId { get; set; } 
            public User Reviewer { get; set; }

            public int Rating { get; set; } 
            public string Comment { get; set; }
        }
    }

