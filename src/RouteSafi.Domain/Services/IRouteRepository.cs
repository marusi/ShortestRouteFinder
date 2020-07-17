using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RouteSafi.Domain.Models;

namespace RouteSafi.Domain.Services
{
   public interface IRouteRepository
    {
        Task Add(Route route);
        Task<List<Route>> GetAllRoutesAsync();
        Task<Route> FindAsync(string from, string to);
    }
}
