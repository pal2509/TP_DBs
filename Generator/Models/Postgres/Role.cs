using System;
using System.Collections.Generic;

namespace Generator
{
    public partial class Role
    {
        public Role()
        {
            UserAccs = new HashSet<UserAcc>();
        }

        public int Id { get; set; }
        public string? Type { get; set; }

        public virtual ICollection<UserAcc> UserAccs { get; set; }
    }
}
