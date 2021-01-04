using System;
using System.Collections.Generic;

namespace PolytechExamBase.Models
{
    public partial class Dbuser
    {
        public Dbuser()
        {
            Journal = new HashSet<Journal>();
            UserPassedTask = new HashSet<UserPassedTask>();
            UserRole = new HashSet<UserRole>();
        }

        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public DateTime? ExpiresIn { get; set; }
        public int? AccessFailedCounts { get; set; }

        public virtual ICollection<Journal> Journal { get; set; }
        public virtual ICollection<UserPassedTask> UserPassedTask { get; set; }
        public virtual ICollection<UserRole> UserRole { get; set; }
    }
}
