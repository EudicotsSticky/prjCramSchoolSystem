using System;
using System.Collections.Generic;

#nullable disable

namespace prjCramSchoolSystem.Models
{
    public partial class UserRole
    {
        public string UserId { get; set; }
        public string RoleId { get; set; }

        public virtual Role Role { get; set; }
        public virtual StudentProfile User { get; set; }
    }
}
