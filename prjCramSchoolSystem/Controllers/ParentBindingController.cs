using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using prjCramSchoolSystem.Data;
using prjCramSchoolSystem.Models.ParentBindingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace prjCramSchoolSystem.Controllers
{
    public class ParentBindingController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public ParentBindingController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [Authorize(Roles = "Default")]
        public async Task<IActionResult> ViewParent()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"無法載入使用者'{_userManager.GetUserName(User)}'.");
            }
            ParentBindingModel parent = await (new ParentBindingModelFactory(_userManager, _signInManager)).LoadParentAsync(user);

            return await Task.Run(() => View(parent));
        }

        // Api:Ajax找，回傳是否有找到家長
        public async Task<IActionResult> FindFatherAsync(string fatherEmailorUsername)
        {
            ApplicationUser fatherData = new ApplicationUser();
            fatherData = await (new ParentBindingModelFactory(_userManager, _signInManager)).FindParentAsync(fatherEmailorUsername);
            if (fatherData != null)
                return Content($"您的父親為：{fatherData.LastName+fatherData.FirstName}");
            else
            return Content("查無此資料");
        }


        // GET: ParentBindingController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ParentBindingController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ParentBindingController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ParentBindingController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ParentBindingController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ParentBindingController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
