using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

using RouteSafi.Domain.Models;


namespace RouteSafi.Domain.Services
{
    public class DocumentService : IDocumentService
    {
       // private readonly IUnitOfWork unitOfWork;
        private readonly IDocumentStorage documentStorage;
        public DocumentService( IDocumentStorage documentStorage)
        {
            this.documentStorage = documentStorage;
          //  this.unitOfWork = unitOfWork;
        }

        public async Task<Document> UploadDocument(Tourist tourist, IFormFile file, string uploadsFolderPath)
        {
            var fileName = await documentStorage.StoreDocument(uploadsFolderPath, file);

            var document = new Document { DocumentFileName = fileName };
            tourist.Documents.Add(document);
         //   await unitOfWork.CompleteAsync();

            return document;
        }
    }
}