using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarSharing.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;

namespace CarSharing.BLL.Services
{
    public class FileService : IFileService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FileService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<string> SaveFileAsync(IFormFile file, string folderName)
        {
            // 1. Отримуємо шлях до wwwroot
            string webRootPath = _webHostEnvironment.WebRootPath;

            // 2. ЯКЩО wwwroot ПУСТИЙ (папки немає) - визначаємо шлях вручну
            if (string.IsNullOrWhiteSpace(webRootPath))
            {
                webRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
            }

            // Тепер webRootPath точно не null, і Path.Combine не впаде
            string uploadsFolder = Path.Combine(webRootPath, "uploads", folderName);

            if (!Directory.Exists(uploadsFolder))
                Directory.CreateDirectory(uploadsFolder);

            string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            return $"/uploads/{folderName}/{uniqueFileName}";
        }

        public Task DeleteFileAsync(string fileUrl)
        {
            string filePath = Path.Combine(_webHostEnvironment.WebRootPath, fileUrl.TrimStart('/'));
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            return Task.CompletedTask;
        }
    }
}
