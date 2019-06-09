using System;
using Microsoft.EntityFrameworkCore;

namespace survivorapi3.Models
{
    public class SurvivorContext : DbContext
    {
        public SurvivorContext(DbContextOptions<SurvivorContext> options)
            : base(options)
        {
        }

        public DbSet<Player> PlayerItems { get; set; }
        public DbSet<Tribe> TribeItems { get; set; }


    }
}