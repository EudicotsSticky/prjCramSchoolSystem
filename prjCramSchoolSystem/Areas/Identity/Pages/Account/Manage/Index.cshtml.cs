using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using prjCramSchoolSystem.Data;

namespace prjCramSchoolSystem.Areas.Identity.Pages.Account.Manage
{
    // 首頁的模組繼承自PageModel
    public partial class IndexModel : PageModel
    {
        // 相依性注入
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly string _folder;

        public IndexModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IWebHostEnvironment webHostEnvironment)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _webHostEnvironment = webHostEnvironment;
            // 把上傳目錄設為：wwwroot\Files\thumbnail
            _folder = $@"{_webHostEnvironment.WebRootPath}\Files\thumbnail";
        }

        // 圖片格式規定
        private readonly static Dictionary<string, string> _contentTypes = new Dictionary<string, string>
        {
            {".png", "image/png"},
            {".jpg", "image/jpeg"},
            {".jpeg", "image/jpeg"},
            {".gif", "image/gif"}
        };

        // 資料模型
        public string Username { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }

            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "名字")]
            public string FirstName { get; set; }

            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "姓")]
            public string LastName { get; set; }

            [DataType(DataType.Text)]
            [Display(Name = "性別")]
            public string Gender { get; set; }

            [DataType(DataType.Date)]
            [Display(Name = "生日")]
            public DateTime? BirthDate { get; set; }

            [DataType(DataType.Text)]
            [Display(Name = "通訊地址")]
            public string Address { get; set; }

            [Display(Name = "入學年度")]
            public string Enrollment { get; set; }

            [Display(Name = "年級")]
            public string Grade { get; set; }

            [Display(Name = "就學狀態")]
            public string Status { get; set; }

            [Display(Name = "大頭貼照")]
            public string ThumbnailUrl { get; set; }

            [Display(Name = "父親名稱")]
            [DataType(DataType.Text)]
            public string FatherName { get; set; }

            [Display(Name = "母親名稱")]
            [DataType(DataType.Text)]
            public string MotherName { get; set; }

            [Display(Name = "個人資料建立日期")]
            [DataType(DataType.Date)]
            public DateTime? CreateDate { get; set; }

            [Display(Name = "最後更新日期")]
            [DataType(DataType.Date)]
            public DateTime? UpdateDate { get; set; }

            // 從input file裡取name為thumbnail的值
            public IFormFile thumbnail { get; set; }
        }
        
        // 載入方法，被後續方法呼叫
        private async Task LoadAsync(ApplicationUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);

            Username = userName;

            Input = new InputModel
            {
                PhoneNumber = phoneNumber,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Address = user.Address,
                BirthDate = user.BirthDate,
                // CreateDate = user.CreateDate,
                // 資料創建日期不給更改
                Enrollment = user.Enrollment,
                FatherName = user.FatherName,
                MotherName = user.MotherName,
                Gender = user.Gender,
                Grade = user.Grade,
                Status = user.Status,
                ThumbnailUrl = user.ThumbnailUrl,
                UpdateDate = user.UpdateDate
            };
        }
       
        // HttpGet方式取得資料
        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            // 發生無預期狀況導致無法以ID載入資料
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }
            // 一般情況就採用載入方法加入user資料
            await LoadAsync(user);
            return Page();
        }

        // HttpPost方法(修改)
        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to set phone number.";
                    return RedirectToPage();
                }
            }
            // 如果資料有更新，更新欄位
            if (Input.Address != user.Address)
                user.Address = Input.Address;
            if (Input.BirthDate != user.BirthDate)
                user.BirthDate = Input.BirthDate;
            //資料創建日期不給更改
            //if (Input.CreateDate != user.CreateDate)
            //    user.CreateDate = Input.CreateDate;
            if (Input.Enrollment != user.Enrollment)
                user.Enrollment = Input.Enrollment;
            if (Input.FatherName != user.FatherName)
                user.FatherName = Input.FatherName;
            if (Input.FirstName != user.FirstName)
                user.FirstName = Input.FirstName;
            if (Input.Gender != user.Gender)
                user.Gender = Input.Gender;
            if (Input.Grade != user.Grade)
                user.Grade = Input.Grade;
            if (Input.LastName != user.LastName)
                user.LastName = Input.LastName;
            if (Input.MotherName != user.MotherName)
                user.MotherName = Input.MotherName;
            //就學狀態需討論
            //if (Input.Status != user.Status)
            //    user.Status = Input.Status;
            if (Input.ThumbnailUrl != user.ThumbnailUrl)
            {
                user.ThumbnailUrl = Input.ThumbnailUrl;

            }

            // 直接更新更改時間，不經過input
            user.UpdateDate = DateTime.Now;


            await _userManager.UpdateAsync(user);

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "您的個人資料已更新成功";
            return RedirectToPage();
        }
    }
}
