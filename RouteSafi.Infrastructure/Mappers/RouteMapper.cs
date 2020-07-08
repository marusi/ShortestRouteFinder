using AutoMapper;

using RouteSafi.Domain.Models;
using RouteSafi.Infrastructure.DTO;

namespace RouteSafi.Infrastructure.Mappers
{
    public static class RouteMapper
    {
        static IMapper mapper;
        static RouteMapper()
        {
            mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RouteCsv, Route>().ReverseMap();
            }).CreateMapper();
        }
        public static Route Map(this RouteCsv route)
        {
            return mapper.Map<Route>(route);
        }
        public static RouteCsv Map(this Route route)
        {
            return mapper.Map<RouteCsv>(route);
        }
    }
}
