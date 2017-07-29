using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TripsieCore.Models
{
    public class TripsieSeedData
    {
        private TripsieContext _context;

        public TripsieSeedData(TripsieContext context)
        {
            _context = context;
        }

        public async Task EnsureSeedData()
        {
            if(!_context.Trips.Any())
            {
                var trip = new Trip()
                {
                    Code = "ABCDE",
                    Description = "Test Trip",
                    Destination = "Chicago",
                    EndDate = DateTime.UtcNow.AddDays(30).ToString(),
                    StartDate = DateTime.UtcNow.AddDays(25).ToString(),
                    MyName = "Travis",
                    UserJson = "{}"
                };

                _context.Trips.Add(trip);

                await _context.SaveChangesAsync();
            }
        }
    }
}
