using System;
using System.Collections.Generic;

namespace Generator
{
    public partial class Payment
    {
        public int PaymentId { get; set; }
        public string Method { get; set; } = null!;
        public float Value { get; set; }
        public Guid UseruserId { get; set; }

        public virtual UserAcc Useruser { get; set; } = null!;
    }
}
