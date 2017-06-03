using TodoApi.Models;
using System;
using System.Linq;

namespace TodoApi.Data
{
    public static class DbInitializer
    {
        public static void Initialize(BeaconContext context)
        {
            context.Database.EnsureCreated();

         
            var beacons = new Beacon[]
            {
               new Beacon{UUID="B9407F30-F5F8-466E-AFF9-25556B57FE6D", Major=14365, Minor=29583,BeaconName="candy", Brand="Estimote"},
               new Beacon{UUID="B9407F30-F5F8-466E-AFF9-25556B57FE6D", Major=2290, Minor=9216,BeaconName="blueberry", Brand="Estimote"}
            };

            foreach (Beacon b in beacons)
            {
                context.Beacons.Add(b);
            }

            context.SaveChanges();

        } //end Initialize



    } //end class
} //end namespace