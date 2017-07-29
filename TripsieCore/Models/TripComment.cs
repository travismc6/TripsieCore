using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TripsieCore.Models
{
    public class TripComment
    {
        [Key]

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int TripUserId { get; set; }

        public string Comment { get; set; }

        public int DetailId { get; set; }

        public TripUser TripUser { get; set; }
    }
}
