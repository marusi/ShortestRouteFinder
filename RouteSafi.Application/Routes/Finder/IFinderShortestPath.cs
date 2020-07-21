using RouteSafi.Application.Routes.FindBestRoute;
using RouteSafi.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RouteSafi.Application.Routes.Finder
{
   public interface IFinderShortestPath
    {
        RouteResponse BestRouteAsync(string from, string to, List<Route> routes);
    }
}
