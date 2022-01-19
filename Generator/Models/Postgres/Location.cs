using System;
using System.Collections.Generic;
using NpgsqlTypes;

namespace Generator
{
    public partial class Location
    {
        public Location()
        {
            Trips = new HashSet<Trip>();
            Vehicles = new HashSet<Vehicle>();
        }

        public int LocationId { get; set; }
        public string? Name { get; set; }
        public NpgsqlPolygon? Coordinates { get; set; }

        public virtual ICollection<Trip> Trips { get; set; }
        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
