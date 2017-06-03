using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Models
{
    public class Beacon
    {
        public int BeaconID { get; set; }
        public string UUID { get; set; }
        public int Major { get; set; }
        public int Minor { get; set; }
        public string BeaconName { get; set; }
        public string Model { get; set; }
        public string Brand { get; set; }

    } //end class
} //end namespace

