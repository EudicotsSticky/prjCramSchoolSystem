using System;
using System.Collections.Generic;

#nullable disable

namespace prjCramSchoolSystem.Models
{
    public partial class TParentProfile
    {
        public int FId { get; set; }
        public string FPaccount { get; set; }
        public string FPpassword { get; set; }
        public string FRelation { get; set; }
        public string FPemail { get; set; }
        public string FPphone { get; set; }
        public string FPtel { get; set; }
        public string FPthumbnail { get; set; }
        public string FCreateDate { get; set; }
        public string FUpdateDate { get; set; }
    }
}
