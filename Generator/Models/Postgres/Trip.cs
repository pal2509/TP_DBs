using System;
using System.Collections.Generic;
using NpgsqlTypes;

namespace Generator
{
    public partial class Trip
    {
        public Trip()
        {
            Incidents = new HashSet<Incident>();
        }

        public Guid TripId { get; set; }
        public Guid VehicleId { get; set; }
        public Guid UserId { get; set; }
        public int LocationId { get; set; }
        public float? Cost { get; set; }
        public int? Length { get; set; }
        public int? Duration { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public short? Rating { get; set; }
        public string? FeedbackDescription { get; set; }
        public NpgsqlPath? Path { get; set; }

        public virtual Location Location { get; set; } = null!;
        public virtual UserAcc User { get; set; } = null!;
        public virtual Vehicle Vehicle { get; set; } = null!;
        public virtual ICollection<Incident> Incidents { get; set; }
    }
}
