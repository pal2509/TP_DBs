using System;
using System.Collections.Generic;

namespace Generator
{
    public partial class UserAcc
    {
        public UserAcc()
        {
            Payments = new HashSet<Payment>();
            Trips = new HashSet<Trip>();
        }

        public Guid UserId { get; set; }
        public string? UserName { get; set; }
        public DateOnly? DateOfBirth { get; set; }
        public float? AccountBalance { get; set; }
        public string? Fullname { get; set; }
        public int Roleid { get; set; }

        public virtual Role Role { get; set; } = null!;
        public virtual ICollection<Payment> Payments { get; set; }
        public virtual ICollection<Trip> Trips { get; set; }
    }
}
