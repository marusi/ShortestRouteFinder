using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

using RouteSafi.Domain.Models;
using RouteSafi.Domain.Services;
using RouteSafi.Infrastructure.DTO;

namespace RouteSafi.Controllers
{
    [Route("/api/touristcsv/{touristId}/documents")]
    public class DocumentsController : Controller
    {

        private readonly IWebHostEnvironment host;
        private readonly ITouristRepository touristRepository;
        private readonly IDocumentRepository documentRepository;
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        private readonly DocumentSettings documentSettings;
        private readonly IDocumentService documentService;
        public DocumentsController(IWebHostEnvironment host, ITouristRepository touristRepository,
            IUnitOfWork unitOfWork, IMapper mapper, IDocumentService documentService, IOptionsSnapshot<DocumentSettings> options,
            IDocumentRepository documentRepository)
        {
            this.documentSettings = options.Value;
            this.host = host;
            this.touristRepository = touristRepository;
            this.documentRepository = documentRepository;
            this.unitOfWork = unitOfWork;
            this.documentService = documentService;
            this.mapper = mapper;
        }




        [HttpGet]
        public async Task<IEnumerable<DocumentDTO>> GetDocuments(int touristId)
        {
            var documents = await documentRepository.GetDocuments(touristId);

            return mapper.Map<IEnumerable<Document>, IEnumerable<DocumentDTO>>(documents);
        }

        [HttpPost]
        public async Task<IActionResult> Upload(int touristId, IFormFile file)
        {
            var tourist = await touristRepository.GetTourist(touristId, includeRelated: false);

            if (tourist == null)
                return NotFound();

            if (file == null) return BadRequest("Null Document File");
            if (file.Length == 0) return BadRequest("Empty Document File");
            if (file.Length > documentSettings.MaxBytes) return BadRequest("Maximum file size exceeded");
            if (!documentSettings.IsSupported(file.FileName)) return BadRequest("File type is invalid");


            var uploadsFolderPath = Path.Combine(host.WebRootPath, "documentUploads");
            if (!Directory.Exists(uploadsFolderPath))
                Directory.CreateDirectory(uploadsFolderPath);

            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

            var filePath = Path.Combine(uploadsFolderPath, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var document = new Document { DocumentFileName = fileName };
            tourist.Documents.Add(document);
            await unitOfWork.CompleteAsync();

            return Ok(mapper.Map<Document, DocumentDTO>(document));
        }
    }
}
