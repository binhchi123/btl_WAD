using Btl.Areas.Admin.Models;
using Btl.Areas.Admin.Models.BusinessModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Btl.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoggingController : Controller
    {
        private readonly BamaContext db;

        public LoggingController(BamaContext _db)
        {
            db = _db;
        }

        [HttpGet]
        public IActionResult Login(string urlRedirect)
        {
            ViewBag.urlRedirect = urlRedirect;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password, string urlRedirect)
        {
            if (string.IsNullOrEmpty(email))
            {
                ViewBag.error = "<div class='alert alert-danger'>Đăng nhập sai</div>";
                return View();
            }
            if (string.IsNullOrEmpty(password))
            {
                ViewBag.error = "<div class='alert alert-danger'>Đăng nhập sai</div>";
                return View();
            }

            // ma hoa md5 password
            var md5pass = Utility.MD5Hash(password);
            // kiem tra nguoi dung trong database
            var acc =  db.Users.FirstOrDefault(x => x.Email == email && x.Password == md5pass);
            if (acc != null)
            {
                var identity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name,acc.FullName),
                    new Claim(ClaimTypes.Role,"admin")
                }, "DefaultSchema") ;
                var principal = new ClaimsPrincipal(identity);
                var login = HttpContext.SignInAsync("DefaultSchema", principal);
                if (!string.IsNullOrEmpty(urlRedirect))
                {
                    return Redirect(urlRedirect);
                }

                return Redirect("/Admin");
            }
            else
            {
                ViewBag.error = "<div class='alert alert-danger'>Đăng nhập sai</div>";
                return View();
            }

        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return Redirect("/Admin/Home/Index");
        }
    }
}
