using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RouteSafi.Domain.Models;

namespace RouteSafi.Domain.Services
{
    public interface IDocumentRepository
    {
        Task<IEnumerable<Document>> GetDocuments(int touristId);
    }
}
