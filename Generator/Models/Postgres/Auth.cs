using System;
using System.Collections.Generic;

namespace Generator
{
    public partial class Auth
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
        public Guid UseruserId { get; set; }

        public virtual UserAcc Useruser { get; set; } = null!;
    }
}
