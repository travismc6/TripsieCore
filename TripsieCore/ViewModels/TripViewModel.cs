using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TripsieCore.ViewModels
{
    public class TripViewModel
    {
        [Required]
        public string Name { get; set; }
        public string Destination { get; set; }
    }
}
