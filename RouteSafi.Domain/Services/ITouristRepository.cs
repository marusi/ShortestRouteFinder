using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RouteSafi.Domain.Models;


namespace RouteSafi.Domain.Services
{
    public interface ITouristRepository
    {

        Task<Tourist> GetTourist(int id, bool includeRelated = true);

      
        void Add(Tourist tourist);
        void Remove(Tourist tourist);

       
      

    }
}
