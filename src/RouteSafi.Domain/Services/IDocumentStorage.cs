using System.Threading.Tasks;
 using Microsoft.AspNetCore.Http;

namespace RouteSafi.Domain.Services
{
    public interface IDocumentStorage
    {
         Task<string> StoreDocument(string uploadsFolderPath, IFormFile file);
    }
}