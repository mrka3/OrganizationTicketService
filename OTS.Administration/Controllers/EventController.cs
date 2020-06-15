using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OTS.Administration.Models.Events.CreateEdit;
using OTS.Administration.Models.Events.Item;
using OTS.Administration.Models.Events.List;

namespace OTS.Administration.Controllers
{
    [Authorize]
    public class EventController : Controller
    {
        private readonly IEventModelBuilder eventModelBuilder;
        private readonly IEventListModelBuilder eventListModelBuilder;
        private readonly IEventEditModelBuilder eventEditModelBuilder;
        private readonly IEventFormValidator eventFormValidator;
        private readonly IEventFormHandler eventFormHandler;

        public EventController(IEventModelBuilder eventModelBuilder, IEventListModelBuilder eventListModelBuilder,
            IEventEditModelBuilder eventEditModelBuilder, IEventFormValidator eventFormValidator,
            IEventFormHandler eventFormHandler)
        {
            this.eventModelBuilder = eventModelBuilder;
            this.eventListModelBuilder = eventListModelBuilder;
            this.eventEditModelBuilder = eventEditModelBuilder;
            this.eventFormValidator = eventFormValidator;
            this.eventFormHandler = eventFormHandler;
        }

        public IActionResult List()
        {
            return View("List", eventListModelBuilder.Build());
        }

        public IActionResult Item(Guid id)
        {
            if(!Guid.TryParse(User.Identity.Name, out var userId)) throw new Exception("У вас нет доступа");

            return View("Item", eventModelBuilder.Build(id, userId));
        }

        public IActionResult Create()
        {
            return View("Form", eventEditModelBuilder.BuildNew());
        }

        [HttpPost]
        public IActionResult Create(EventForm form)
        {
            var valResult = eventFormValidator.ValidateOnCreate(form, ModelState);

            if (valResult.ModelState.IsValid)
            {
                var id = eventFormHandler.HandleCreate(form);
                return RedirectToAction("Item", new {id});
            }

            return View("Form", eventEditModelBuilder.BuildByForm(null, form));
        }

        public IActionResult Edit(Guid id)
        {
            return View("Form", eventEditModelBuilder.BuildEdit(id));
        }

        [HttpPost]
        public IActionResult Edit(Guid id, EventForm form)
        {
            var valResult = eventFormValidator.ValidateOnEdit(id, form, ModelState);

            if (valResult.ModelState.IsValid)
            {
                eventFormHandler.HandleEdit(form, valResult);
                return RedirectToAction("Item", new {id});
            }

            return View("Form", eventEditModelBuilder.BuildByForm(id, form));
        }
    }
}