using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TodoApi.Models
{
    public class BeaconContext : DbContext
    {
        public BeaconContext(DbContextOptions<BeaconContext> options) : base(options)
        {
        }

        public DbSet<Beacon> Beacons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Beacon>().ToTable("Beacon");
        }


    } //end class


} //end namespace

