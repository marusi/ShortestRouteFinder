using RouteSafi.Application.Routes.FindBestRoute;
using System.Threading.Tasks;

namespace RouteSafi.Application.Services
{
    public interface IRouteService
    {
        Task<RouteResponse> FindBestRoute(RouteRequest routeRequest);
    }
}
