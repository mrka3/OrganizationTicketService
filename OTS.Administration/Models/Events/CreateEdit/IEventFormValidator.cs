using System;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace OTS.Administration.Models.Events.CreateEdit
{
    public interface IEventFormValidator
    {
        EventValidationResult ValidateOnCreate(EventForm form, ModelStateDictionary model);
        EventValidationResult ValidateOnEdit(Guid id, EventForm form, ModelStateDictionary model);
    }
}