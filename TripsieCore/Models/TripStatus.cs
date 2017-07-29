using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TripsieCore.Models
{
    public enum TripStatus
    {
        Open,
        Complete,
        Canceled
    }

    public enum TripUserStatus
    {
        Pending,
        Yes,
        No
    }
}
