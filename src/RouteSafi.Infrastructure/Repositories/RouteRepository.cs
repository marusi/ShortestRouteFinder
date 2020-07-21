using CsvHelper;
using RouteSafi.Domain.Services;
using RouteSafi.Domain.Models;
using RouteSafi.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Diagnostics;
using System.Reflection.Metadata;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Hosting;
using RouteSafi.Infrastructure.Mappers;



namespace RouteSafi.Infrastructure.Repositories
{
   public class RouteRepository : IRouteRepository
    {
        IWebHostEnvironment _env;

        

        public string csvFileName()
        {
            string fileName = "";
            var options = new JsonSerializerOptions
            {
                IgnoreReadOnlyProperties = true,
                WriteIndented = true
            };
            // hard coded value of 1 representing a tourist 
            var fileSrcObject = documentRepository.GetDocuments(2);
            var json = JsonSerializer.Serialize(fileSrcObject, options);


            using (JsonDocument document = JsonDocument.Parse(json))
            {
                JsonElement root = document.RootElement;
                JsonElement fileNameElement = root.GetProperty("Result");
                foreach (JsonElement csvFileName in fileNameElement.EnumerateArray())
                {
                    if (csvFileName.TryGetProperty("DocumentFileName", out JsonElement csvValueName))
                    {

                        fileName = csvValueName.ToString();
                        // Debug.WriteLine($" this is the {fileName}");
                    }
                   
                }
                Debug.WriteLine($" this is the {fileName}");
                return fileName;
            }
         
        }

        public string CSVPath => Path.Combine(_env.WebRootPath, $"documentUploads/{csvFileName()}");

        private readonly IDocumentRepository documentRepository;
        public RouteRepository(IWebHostEnvironment env, IDocumentRepository documentRepository)
        {
            _env = env;

            this.documentRepository = documentRepository;
        }

     
        public async Task<List<Route>> GetAllRoutesAsync()
        {
            return await GetAllRouteFromPathAsync(CSVPath);
        }

        public async Task<List<Route>> GetAllRouteFromPathAsync(string filePath)
        {

            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Configuration.HasHeaderRecord = false;
                var records = csv.GetRecords<RouteCsv>();
                var routes = records.ToList().Select(c => c.Map()).ToList();
                return await Task.FromResult(routes);
            }
        }

        public async Task Add(Route route)
        {
            using (var writer = new StreamWriter(CSVPath, append: true))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.Configuration.HasHeaderRecord = false;
                var record = route.Map();
                csv.WriteRecord<RouteCsv>(record);
                csv.NextRecord();
                await Task.CompletedTask;
            }
        }
        public async Task<Route> FindAsync(string from, string to)
        {
            var list = await GetAllRoutesAsync();
            return list.FirstOrDefault(r =>
            {
                return r.Origin.Equals(from, StringComparison.InvariantCultureIgnoreCase)
                    && r.Destination.Equals(to, StringComparison.InvariantCultureIgnoreCase);
            });
        }
    }
}

