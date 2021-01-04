using System;
using System.Collections.Generic;

namespace PolytechExamBase.Models
{
    public partial class UserPassedTask
    {
        public int UserPassedTaskId { get; set; }
        public int PassedTaskPassedTaskId { get; set; }
        public int UserUserId { get; set; }

        public virtual PassedTask PassedTaskPassedTask { get; set; }
        public virtual Dbuser UserUser { get; set; }
    }
}
