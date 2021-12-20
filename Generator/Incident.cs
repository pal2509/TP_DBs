using System;
using System.Collections.Generic;
using NpgsqlTypes;

namespace Generator
{
    public partial class Incident
    {
        public int Id { get; set; }
        public Guid TriptripId { get; set; }
        public string? Type { get; set; }
        public string? Description { get; set; }
        public DateTime? Datetime { get; set; }
        public NpgsqlPoint? Location { get; set; }

        public virtual Trip Triptrip { get; set; } = null!;
    }
}
