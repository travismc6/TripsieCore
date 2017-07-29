using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TripsieCore.Models
{
    public class TripsieRepository : ITripsieRepository
    {
        private TripsieContext _context;

        public TripsieRepository(TripsieContext context)
        {
            _context = context;
        }

        public void AddTrip(Trip trip)
        {
            _context.Add(trip);
        }

        public IEnumerable<Trip> GetTrips()
        {
            return _context.Trips.ToList();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

    }
}
