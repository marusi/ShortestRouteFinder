
using RouteSafi.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace RouteSafi.Application.Routes.FindBestRoute
{
   public class RouteResponse
    {

        public string Origin { get; set; }
        public string Destination { get; set; }
        public List<Route> Routes { private get; set; }
        public List<string> Path => Routes.Select(r => r.Origin)
            .Union(new string[] { Routes.Last().Destination })
            .ToList();
        public decimal TotalCost { get; set; }
    }
}
