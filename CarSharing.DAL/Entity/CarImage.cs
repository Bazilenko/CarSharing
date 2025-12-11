using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSharing.DAL.Entity
{
    public class CarImage : BaseEntity
    {
        public int CarId { get; set; }
        public Car Car { get; set; }

        public string ImageUrl { get; set; }
        public bool IsMain { get; set; }
    }
}
