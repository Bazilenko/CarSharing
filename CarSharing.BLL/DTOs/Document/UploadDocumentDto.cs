using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace CarSharing.BLL.DTOs
{
    public class UploadDocumentDto
    {
        public string Type { get; set; } 
        public IFormFile File { get; set; } 
    }
}
