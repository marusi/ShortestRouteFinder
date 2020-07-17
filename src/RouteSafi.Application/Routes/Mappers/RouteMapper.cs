using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace RouteSafi.Application.Routes.Mappers
{
    public static class RouteMapper
    {
        public static IMapper mapper;
        static RouteMapper()
        {
            mapper = new MapperConfiguration(cfg =>
            {
                
            }).CreateMapper();
        }

        
    }
}
