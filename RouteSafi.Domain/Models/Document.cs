using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RouteSafi.Domain.Models
{
    public class Document
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string DocumentFileName { get; set; }

        public int TouristId { get; set; }
    }
}
