using System;
using System.Collections.Generic;

namespace PolytechExamBase.Models
{
    public partial class MarkJournal
    {
        public int MarkJournalId { get; set; }
        public int JournalJournalId { get; set; }
        public int MarkMarkId { get; set; }

        public virtual Journal JournalJournal { get; set; }
        public virtual Mark MarkMark { get; set; }
    }
}
