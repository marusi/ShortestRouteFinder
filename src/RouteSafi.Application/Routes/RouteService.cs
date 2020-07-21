using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Algorithms.ShortestRoute.Dijkstra;
using RouteSafi.Application.Routes.FindBestRoute;
using RouteSafi.Application.Routes.Finder;
using RouteSafi.Application.Services;
using RouteSafi.Domain.Models;
using RouteSafi.Domain.Services;

namespace RouteSafi.Application.Routes
{
   public class RouteService : IRouteService
    {
        public IRouteRepository _repository { get; set; }
        public IFinderShortestPath _finder { get; set; }

        public RouteService(IRouteRepository repository, IFinderShortestPath finder)
        {
            _repository = repository;
            _finder = finder;
        }

        public async Task<RouteResponse> FindBestRoute(RouteRequest routeRequest)
        {
            List<Route> routes = await _repository.GetAllRoutesAsync();
            var response = _finder.BestRouteAsync(routeRequest.From, routeRequest.To, routes);
            return await Task.FromResult(response);
        }
    }
}
