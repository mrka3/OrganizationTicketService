using System;

namespace OTS.Administration.Models.Events.CreateEdit
{
    public interface IEventFormHandler
    {
        Guid HandleCreate(EventForm form);
        void HandleEdit(EventForm form, EventValidationResult valResult);
    }
}