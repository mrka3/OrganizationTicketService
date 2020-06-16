using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OTS.Administration.Models.Auth;

namespace OTS.Administration.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILoginModelHandler loginModelHandler;

        public HomeController(ILoginModelHandler loginModelHandler)
        {
            this.loginModelHandler = loginModelHandler;
        }

        [Authorize]
        public IActionResult Index()
        {
            if(!Guid.TryParse(User.Identity.Name, out var userId)) throw new Exception("Нет доступа");

            if (loginModelHandler.IsAdmin(userId))
                return View();

            return RedirectToAction("ListService", "Event");
        }
    }
}
