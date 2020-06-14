using Microsoft.AspNetCore.Mvc.ModelBinding;
using OTS.DataLayer.Entities.Events;

namespace OTS.Administration.Models.Events.CreateEdit
{
    public class EventValidationResult
    {
        public ModelStateDictionary ModelState { get; set; }
        public Event Event { get; set; }

        public EventValidationResult(ModelStateDictionary modelState, Event @event)
        {
            ModelState = modelState;
            Event = @event;
        }
    }
}