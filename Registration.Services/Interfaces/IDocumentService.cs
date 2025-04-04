using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Registration.Services.Interfaces
{
    public interface IDocumentService
    {
        Task<string> UploadDocumentAsync(IFormFile file, string containerName);
        Task<bool> DeleteDocumentAsync(string documentPath, string containerName);
    }
}
