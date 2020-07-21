using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using RouteSafi.Domain.Models;

namespace RouteSafi.Domain.Services
{
    public interface IDocumentService
    {
        Task<Document> UploadDocument(Tourist tourist, IFormFile file, string uploadsFolderPath);
    }
}