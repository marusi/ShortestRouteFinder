using System;
using System.Collections.Generic;
using System.Text;
using CsvHelper.Configuration.Attributes;

namespace RouteSafi.Infrastructure.DTO
{
   public class RouteCsv
    {

        [Index(0)]
        public string Origin { get; set; }
        [Index(1)]
        public string Destination { get; set; }
        [Index(2)]
        public decimal Cost { get; set; }
    }
}
