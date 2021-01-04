using System;
using System.Collections.Generic;

namespace PolytechExamBase.Models
{
    public partial class Mark
    {
        public Mark()
        {
            MarkJournal = new HashSet<MarkJournal>();
        }

        public int MarkId { get; set; }
        public int? MarkNumber { get; set; }
        public string MarkString { get; set; }
        public int PassedTaskPassedTaskId { get; set; }

        public virtual PassedTask PassedTaskPassedTask { get; set; }
        public virtual ICollection<MarkJournal> MarkJournal { get; set; }
    }
}
