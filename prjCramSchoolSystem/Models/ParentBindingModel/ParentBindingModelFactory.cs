using Microsoft.AspNetCore.Identity;
using prjCramSchoolSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace prjCramSchoolSystem.Models.ParentBindingModel
{
    public class ParentBindingModelFactory
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public ParentBindingModelFactory(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<ParentBindingModel> LoadParentAsync(ApplicationUser user)
        {
            ParentBindingModel Input = new ParentBindingModel();
            Input.Id = user.Id;
            Input.MotherId = user.MotherId;
            Input.FatherId = user.FatherId;
            Input.Father = user.Father;
            Input.Mother = user.Mother;
            if (user.Father != null)
                Input.FatherName = user.Father.LastName + user.Father.FirstName;
            if (user.Mother != null)
                Input.MotherName = user.Mother.LastName + user.Mother.FirstName;

            return await Task.Run(() => Input);
        }

        public async Task<ApplicationUser> FindParentAsync(string nameOrEmail)
        {
            ApplicationUser parentData = new ApplicationUser();
            if (IsValidEmail(nameOrEmail))
                parentData = await _userManager.FindByEmailAsync(nameOrEmail);
            else
                parentData = await _userManager.FindByNameAsync(nameOrEmail);

            return parentData;
        }

        public bool IsValidEmail(string emailAddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailAddress);
                return true;
            }
            catch (FormatException ex)
            {
                return false;
            }
        }
    }
}
