
// using CQRSHelper._Common;
using RouteSafi.Domain.Services;
using RouteSafi.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;
using RouteSafi.Domain.Models;
using System.Configuration;
using AutoMapper;
using RouteSafi.Application.Services;
using RouteSafi.Application.Routes;
using RouteSafi.Application.Routes.Finder;

namespace RouteSafi.Infrastructure.DI
{
  public  class Loader
   {
      
        public static void Register(IServiceCollection services, Microsoft.Extensions.Configuration.IConfiguration cfg)
        {
            var conn = cfg.GetConnectionString("Default");
           // services.AddAutoMapper(typeof(Loader));
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(conn));

          //  services.Configure<DocumentSettings>(Configuration.GetSection("DocumentSettings"));

            services.AddScoped<IDocumentRepository, DocumentRepository>();
            services.AddTransient<IDocumentService, DocumentService>();

            services.AddScoped<ITouristRepository, TouristRepository>();
            services.AddTransient<IRouteService, RouteService>();
            services.AddTransient<IRouteRepository, RouteRepository>();
            services.AddSingleton<IFinderShortestPath, DijkstraAdapter>();
            services.AddTransient<IDocumentStorage, FileSystemDocumentStorage>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            //  services.AddScoped<ITransferRepository, TrasnferRepository>();

            //   setMediator(typeof(AccountQueryHandler));
            //   setMediator(typeof(TrasnferCommandHandler));
            //foreach (var item in CQRSHelper.Loader.GetAll())
            //{
            //    setMediator(item);
            //}
        }
    }
}
