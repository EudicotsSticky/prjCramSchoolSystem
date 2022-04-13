using System;
using System.Collections.Generic;

#nullable disable

namespace prjCramSchoolSystem.Models
{
    public partial class TStudentProfile
    {
        public int FId { get; set; }
        public string FAccount { get; set; }
        public string FPassword { get; set; }
        public string FName { get; set; }
        public string FGender { get; set; }
        public DateTime? FBirthDate { get; set; }
        public string FPhone { get; set; }
        public string FEmail { get; set; }
        public string FAddress { get; set; }
        public string FEnrollment { get; set; }
        public string FGrade { get; set; }
        public string FStatus { get; set; }
        public string FThumbnailUrl { get; set; }
        public string FParentName { get; set; }
        public DateTime? FCreateDate { get; set; }
        public DateTime? FUpdateDate { get; set; }
    }
}
