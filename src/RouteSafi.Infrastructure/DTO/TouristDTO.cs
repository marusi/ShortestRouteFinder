using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;


namespace RouteSafi.Infrastructure.DTO
{
    public class TouristDTO
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime LastUpdate { get; set; }
        public ICollection<DocumentDTO> Documents { get; set; }

        public TouristDTO()
        {
            Documents = new Collection<DocumentDTO>();  
        }
    }
}
