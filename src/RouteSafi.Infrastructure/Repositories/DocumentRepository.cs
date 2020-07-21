using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RouteSafi.Domain.Models;



using RouteSafi.Domain.Services;

namespace RouteSafi.Infrastructure.Repositories
{
    public class DocumentRepository : IDocumentRepository
    {
        private readonly AppDbContext context;
        public DocumentRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<Document>> GetDocuments(int touristId)
        {
            return await context.Documents
              .Where(p => p.TouristId == touristId)
              .ToListAsync();
        }
    }
}