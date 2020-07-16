
using System.Collections.Generic;


namespace RouteSafi.Application.Routes.FindBestRoute
{
   public class RouteResponse
    {
        public List<string> Routes { get; set; }

        public decimal TotalCost { get; set; }
    }
}
