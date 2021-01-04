using System;
using System.Collections.Generic;

namespace PolytechExamBase.Models
{
    public partial class Difficulty
    {
        public Difficulty()
        {
            Task = new HashSet<Task>();
        }

        public int DifficultyId { get; set; }
        public int? DifficultyLevel { get; set; }

        public virtual ICollection<Task> Task { get; set; }
    }
}
