using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public interface IAppRepository
    {
        IEnumerable<Trip> GetAllTrips();
        Trip GetTripByName(string tripName);
        void AddTrip(Trip trip);
        void AddStop(string tripName, Stop newStop);
        Task<bool> SaveChangesAsync();
        
    }
}