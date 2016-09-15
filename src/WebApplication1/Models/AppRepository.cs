using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class AppRepository : IAppRepository
    {
        private AppDbContext _context;
        private ILogger<AppRepository> _logger;

        public AppRepository(AppDbContext context, ILogger<AppRepository> logger)
        {
            _logger = logger;
            _context = context;
        }

        public IEnumerable<Trip> GetAllTrips()
        {
            _logger.LogInformation($"[{DateTime.UtcNow}] Getting All Trips from the Database");
            return _context.Trips.ToList();
        }
    }
}
