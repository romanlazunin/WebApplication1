using System.Collections.Generic;

namespace WebApplication1.Models
{
    public interface IAppRepository
    {
        IEnumerable<Trip> GetAllTrips();
    }
}