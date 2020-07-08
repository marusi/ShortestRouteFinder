using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using RouteSafi.Domain.Models;


namespace RouteSafi.Domain.Models
{
    [Table("Tourists")]
    public class Tourist 
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Document> Documents { get; set; }

        public DateTime LastUpdate { get; set; }

       

        public Tourist()
        {
         
            Documents = new Collection<Document>();
        }

    }
}