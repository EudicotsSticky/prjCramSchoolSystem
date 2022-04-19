using System;
using System.Collections.Generic;

#nullable disable

namespace prjCramSchoolSystem.Models
{
    public partial class UserLogin
    {
        public string LoginProvider { get; set; }
        public string ProviderKey { get; set; }
        public string ProviderDisplayName { get; set; }
        public string UserId { get; set; }

        public virtual StudentProfile User { get; set; }
    }
}
