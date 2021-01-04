using System;
using System.Collections.Generic;

namespace PolytechExamBase.Models
{
    public partial class TaskTestTopic
    {
        public int TaskTestTopicId { get; set; }
        public int TestTopicTopicId { get; set; }
        public int TaskTaskId { get; set; }

        public virtual Task TaskTask { get; set; }
        public virtual TestTopic TestTopicTopic { get; set; }
    }
}
