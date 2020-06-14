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

        public AccountController(ILoginModelHandler loginModelHandler)
        {
            this.loginModelHandler = loginModelHandler;
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

        private async Task Authenticate(string userName)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }
    }
}