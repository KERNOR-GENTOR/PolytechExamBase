using System;
using System.Collections.Generic;

namespace PolytechExamBase.Models
{
    public partial class PassedTask
    {
        public PassedTask()
        {
            Mark = new HashSet<Mark>();
            UserPassedTask = new HashSet<UserPassedTask>();
        }

        public int PassedTaskId { get; set; }
        public string GivenAnswer { get; set; }
        public string IsRight { get; set; }
        public int TaskTaskId { get; set; }

        public virtual Task TaskTask { get; set; }
        public virtual ICollection<Mark> Mark { get; set; }
        public virtual ICollection<UserPassedTask> UserPassedTask { get; set; }
    }
}
