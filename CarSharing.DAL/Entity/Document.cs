using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSharing.DAL.Entity
{
    public class Document : BaseEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public string Type { get; set; } 
        public string FileUrl { get; set; } // Посилання на файл у хмарі (AWS S3/Blob)
        public string Status { get; set; } 
    }
}
