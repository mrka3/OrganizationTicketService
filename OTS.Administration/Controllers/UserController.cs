using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OTS.Administration.Models.Users.CreateEdit;
using OTS.Administration.Models.Users.List;

namespace OTS.Administration.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly IUserModelBuilder userModelBuilder;
        private readonly IUserListModelBuilder userListModelBuilder;
        private readonly IUserFormHanlder userFormHanlder;

        public UserController(IUserModelBuilder userModelBuilder, IUserListModelBuilder userListModelBuilder, IUserFormHanlder userFormHanlder)
        {
            this.userModelBuilder = userModelBuilder;
            this.userListModelBuilder = userListModelBuilder;
            this.userFormHanlder = userFormHanlder;
        }

        public IActionResult List()
        {
            return View("List", userListModelBuilder.Build());
        }
        public IActionResult Create()
        {
            return View("Form", userModelBuilder.BuildNew());
        }
        [HttpPost]
        public IActionResult Create(UserForm form)
        {
            userFormHanlder.HandleCreate(form);

            return RedirectToAction("List");
        }
        public IActionResult Edit(Guid id)
        {
            return View("Form", userModelBuilder.BuildEdit(id));
        }
        [HttpPost]
        public IActionResult Edit(Guid id, UserForm form)
        {
            userFormHanlder.HandleEdit(id, form);
            return RedirectToAction("List");
        }
    }
}