using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Registration.Services.Interfaces;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Registration.Services.Services
{
    public class DocumentService : IDocumentService
    {
        private readonly IConfiguration _configuration;
        private readonly string _storageBasePath;

        public DocumentService(IConfiguration configuration)
        {
            _configuration = configuration;
            
            _storageBasePath = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
            
            if (!Directory.Exists(_storageBasePath))
            {
                Directory.CreateDirectory(_storageBasePath);
            }
        }

        public async Task<string> UploadDocumentAsync(IFormFile file, string containerName)
        {
            if (file == null || file.Length == 0)
            {
                throw new ArgumentException("File is empty or null", nameof(file));
            }

            var containerPath = Path.Combine(_storageBasePath, containerName);
            if (!Directory.Exists(containerPath))
            {
                Directory.CreateDirectory(containerPath);
            }

            var fileName = $"{Guid.NewGuid()}_{Path.GetFileName(file.FileName)}";
            var filePath = Path.Combine(containerPath, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return $"{containerName}/{fileName}";
        }

        public Task<bool> DeleteDocumentAsync(string documentPath, string containerName)
        {
            try
            {
                var fullPath = Path.Combine(_storageBasePath, documentPath);
                if (File.Exists(fullPath))
                {
                    File.Delete(fullPath);
                    return Task.FromResult(true);
                }
                return Task.FromResult(false);
            }
            catch (Exception)
            {
                return Task.FromResult(false);
            }
        }
    }
}
