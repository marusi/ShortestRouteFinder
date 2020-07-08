using System;
using System.Collections.Generic;
using System.Text;

namespace RouteSafi.Domain.Models
{
    public class Route
    {
        public string Origin { get; set; }
        public string Destination { get; set; }

        public decimal Cost { get; set; }
    }
}
