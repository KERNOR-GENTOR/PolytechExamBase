using System;
using System.Collections.Generic;

namespace PolytechExamBase.Models
{
    public partial class Journal
    {
        public Journal()
        {
            MarkJournal = new HashSet<MarkJournal>();
        }

        public int JournalId { get; set; }
        public int UserUserId { get; set; }

        public virtual Dbuser UserUser { get; set; }
        public virtual ICollection<MarkJournal> MarkJournal { get; set; }
    }
}
