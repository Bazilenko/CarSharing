using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSharing.BLL.DTOs.Review
{
    public class CreateReviewDto
    {
        public int BookingId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
    }
}
