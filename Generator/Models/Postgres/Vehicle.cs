using System;
using System.Collections.Generic;
using NpgsqlTypes;

namespace Generator
{
    public partial class Vehicle
    {
        public Vehicle()
        {
            Trips = new HashSet<Trip>();
        }

        public Guid VehicleId { get; set; }
        public int LocationId { get; set; }
        public string? Name { get; set; }
        public string? Model { get; set; }
        public string? Brand { get; set; }
        public int? Autonomy { get; set; }
        public DateTime? Startdate { get; set; }
        public float? HourRate { get; set; }
        public string? State { get; set; }
        public int? BatteryLevel { get; set; }
        public NpgsqlPoint? Currentlocation { get; set; }

        public virtual Location Location { get; set; } = null!;
        public virtual ICollection<Trip> Trips { get; set; }
    }
}
