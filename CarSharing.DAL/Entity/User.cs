using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using CarSharing.DAL.Enums;

namespace CarSharing.DAL.Entity
{
        public class User : BaseEntity
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string PasswordHash { get; set; } 
            public string PhoneNumber { get; set; }
            public DateTime BirthDate { get; set; }

            public UserRole Role { get; set; }
            public bool IsVerified { get; set; } = false;

            
            public ICollection<Document> Documents { get; set; }
            public ICollection<Car> OwnedCars { get; set; }      
            public ICollection<Booking> Bookings { get; set; }   
            public ICollection<Review> ReviewsWritten { get; set; }
        }
}
