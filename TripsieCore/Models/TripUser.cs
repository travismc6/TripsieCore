using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using static TripsieCore.Models.TripStatus;

namespace TripsieCore.Models
{
    public class TripUser
    {
        [Key]

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }

        public int? TripId { get; set; }

        public Trip Trip { get; set; }

        public string DisplayName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public bool IsCreator { get; set; }

        public string TripCode { get; set; }

        public TripUserStatus TripStatus { get; set; }

        public long Lat { get; set; }

        public long Lon { get; set; }

        public IEnumerable<TripComment> TripComments { get; set; }
    }
}
