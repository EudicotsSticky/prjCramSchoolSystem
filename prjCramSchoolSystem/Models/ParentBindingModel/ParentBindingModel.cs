﻿using prjCramSchoolSystem.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace prjCramSchoolSystem.Models.ParentBindingModel
{
    public class ParentBindingModel
    {
        [Key]
        public string Id { get; set; }

        [Display(Name ="請輸入父親帳號或信箱進行綁定：")]
        public string FatherEmailorUsername { get; set; }

        [Display(Name = "請輸入母親帳號或信箱進行綁定：")]
        public string MotherEmailorUsername { get; set; }

        public string FatherId { get; set; }

        public string MotherId { get; set; }

        [ForeignKey("FatherId")]
        public virtual ApplicationUser Father { get; set; }

        [ForeignKey("MotherId")]
        public virtual ApplicationUser Mother { get; set; }

        [Display(Name = "父親名稱")]
        public string FatherName { get; set; }

        [Display(Name = "母親名稱")]
        public string MotherName { get; set; }
    }

}