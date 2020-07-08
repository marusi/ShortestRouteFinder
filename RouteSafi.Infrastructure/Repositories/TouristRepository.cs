

using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using System.Linq;
using System.Collections.Generic;
using RouteSafi.Domain.Services;
using RouteSafi.Domain.Models;

namespace RouteSafi.Infrastructure.Repositories
{

    public class TouristRepository : ITouristRepository
    {
        private readonly AppDbContext context;

        public TouristRepository(AppDbContext context)
        {
            this.context = context;

        }

        public async Task<Tourist> GetTourist(int id, bool includeRelated = true)
        {
            if (!includeRelated)
                return await context.Tourists.FindAsync(id);


            return await context.Tourists.SingleOrDefaultAsync(p => p.Id == id);
        }

        public void Add(Tourist tourist)
        {
            context.Tourists.Add(tourist);

        }

        public void Remove(Tourist tourist)
        {
            context.Remove(tourist);
        }
    }
 
 
            
    }

