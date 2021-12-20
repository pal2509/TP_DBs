using System;
using System.Collections.Generic;

namespace Generator
{
    public partial class Notification
    {
        public Guid UseruserId { get; set; }
        public int? Id { get; set; }
        public string? Type { get; set; }
        public string? Description { get; set; }
        public string? State { get; set; }

        public virtual UserAcc Useruser { get; set; } = null!;
    }
}
