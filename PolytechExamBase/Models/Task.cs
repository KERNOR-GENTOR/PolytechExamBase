using System;
using System.Collections.Generic;

namespace PolytechExamBase.Models
{
    public partial class Task
    {
        public Task()
        {
            PassedTask = new HashSet<PassedTask>();
            TaskTestTopic = new HashSet<TaskTestTopic>();
        }

        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public string Question { get; set; }
        public string Solution { get; set; }
        public int DifficultyDifficultyId { get; set; }

        public virtual Difficulty DifficultyDifficulty { get; set; }
        public virtual ICollection<PassedTask> PassedTask { get; set; }
        public virtual ICollection<TaskTestTopic> TaskTestTopic { get; set; }
    }
}
