using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;

namespace WebApplication1.Models
{
    public class AppUser : IdentityUser
    {
        public DateTime FirstTrip { get; set; }
    }
}