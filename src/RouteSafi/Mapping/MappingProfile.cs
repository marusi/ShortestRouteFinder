using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using RouteSafi.Infrastructure.DTO;
using RouteSafi.Domain.Models;

namespace RouteSafi.Mapping
{
    public class MappingProfile : Profile
    {



        public MappingProfile()
        {
            // Domain to API DTO

            CreateMap<Document, DocumentDTO>();
           // CreateMap<Route, RouteCsv>();
            CreateMap<Tourist, SaveTouristDTO>();
            CreateMap<Tourist, TouristDTO>()

               .ForMember(pr => pr.Documents, opt => opt.MapFrom(p => p.Documents.Select(ps => new DocumentDTO
               {
                   Id = ps.Id,
                   DocumentFileName = ps.DocumentFileName,
               })));
            //API DTO to Domain
            CreateMap<SaveTouristDTO, Tourist>()
            .ForMember(p => p.Id, opt => opt.Ignore());


        }

        
    }
}
