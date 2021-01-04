using System;
using System.Collections.Generic;

namespace PolytechExamBase.Models
{
    public partial class UserRole
    {
        public int UserRoleId { get; set; }
        public int RoleRoleId { get; set; }
        public int UserUserId { get; set; }

        public virtual Role RoleRole { get; set; }
        public virtual Dbuser UserUser { get; set; }
    }
}
