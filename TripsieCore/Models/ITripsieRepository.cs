using System.Collections.Generic;
using System.Threading.Tasks;

namespace TripsieCore.Models
{
    public interface ITripsieRepository
    {
        IEnumerable<Trip> GetTrips();

        void AddTrip(Trip trip);

        Task<bool> SaveChangesAsync();
    }
}