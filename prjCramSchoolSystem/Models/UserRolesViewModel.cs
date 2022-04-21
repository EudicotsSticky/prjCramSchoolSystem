﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace prjCramSchoolSystem.Models
{
    // 此ViewModel用來記錄使用者與其權限，其中權限列舉於Enums/Roles.cs中
    public class UserRolesViewModel
    {
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public IEnumerable<string> Roles { get; set; }
    }
}
