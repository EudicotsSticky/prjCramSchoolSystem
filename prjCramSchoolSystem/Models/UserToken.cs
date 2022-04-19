using System;
using System.Collections.Generic;

#nullable disable

namespace prjCramSchoolSystem.Models
{
    public partial class UserToken
    {
        public string UserId { get; set; }
        public string LoginProvider { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }

        public virtual StudentProfile User { get; set; }
    }
}
