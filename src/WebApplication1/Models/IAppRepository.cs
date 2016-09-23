using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public interface IAppRepository
    {
        IEnumerable<Trip> GetAllTrips();
        IEnumerable<Trip> GetUserTripsWithStops(string name);
        Trip GetTripByName(string tripName, string userName);
        void AddTrip(Trip trip);
        void AddStop(string tripName, Stop newStop, string userName);
        Task<bool> SaveChangesAsync();
    }
}