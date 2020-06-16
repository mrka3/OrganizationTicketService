using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using OTS.Administration.Models.Auth;

namespace OTS.Administration.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILoginModelHandler loginModelHandler;
        private readonly IProfileModelBuilder profileModelBuilder;
        public AccountController(ILoginModelHandler loginModelHandler, IProfileModelBuilder profileModelBuilder)
        {
            this.loginModelHandler = loginModelHandler;
            this.profileModelBuilder = profileModelBuilder;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var id = loginModelHandler.GetUserId(model.Login);

            if (!id.HasValue)
            {
                ModelState.AddModelError("Login", "Пользователя с таким логином не существует");
                return View(model);
            }

            if (loginModelHandler.IsPasswordValid(model))
            {
                await Authenticate(id.ToString());
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("Password", "Неверный пароль");

            return View(model);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (!ModelState.IsValid) return View(model);

            if (!loginModelHandler.IsExist(model.Login))
            {
                var id = loginModelHandler.Create(model);

                await Authenticate(id.ToString());

                return RedirectToAction("Index", "Home");
            }
            
            ModelState.AddModelError("Login", "Пользователь с таким логином уже существует");

            return View(model);
        }

        public IActionResult Profile()
        {
            if (!Guid.TryParse(User.Identity.Name, out var userId)) throw new Exception("Нет доступа");

            return View(profileModelBuilder.Build(userId));
        }
        [HttpPost]
        public IActionResult Profile(ProfileModel model)
        {
            if(!Guid.TryParse(User.Identity.Name, out var userId)) throw new Exception("Нет доступа");

            if (!ModelState.IsValid) return View(model);

            loginModelHandler.Edit(userId, model);

            return RedirectToAction("Profile");
        }

        private async Task Authenticate(string userName)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };
            var id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }


    }
}