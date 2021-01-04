using System;
using System.Collections.Generic;

namespace PolytechExamBase.Models
{
    public partial class TestTopic
    {
        public TestTopic()
        {
            TaskTestTopic = new HashSet<TaskTestTopic>();
        }

        public int TopicId { get; set; }
        public string TopicName { get; set; }

        public virtual ICollection<TaskTestTopic> TaskTestTopic { get; set; }
    }
}
