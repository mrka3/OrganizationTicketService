using System;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using OTS.DataLayer.Entities.Events;

namespace OTS.Administration.Models.Events.CreateEdit
{
    public class EventFormValidator : IEventFormValidator
    {
        private readonly IEventRepository eventRepository;

        public EventFormValidator(IEventRepository eventRepository)
        {
            this.eventRepository = eventRepository;
        }

        public EventValidationResult ValidateOnCreate(EventForm form, ModelStateDictionary model)
        {
            ValidateData(form, model);

            return new EventValidationResult(model, new Event());
        }

        public EventValidationResult ValidateOnEdit(Guid id, EventForm form, ModelStateDictionary model)
        {
            var eventModel = eventRepository.Find(id);

            if(eventModel == null) throw new Exception("Мероприятие не найдено");

            ValidateData(form, model);

            return new EventValidationResult(model, eventModel);
        }

        private void ValidateData(EventForm form, ModelStateDictionary model)
        {
            if (string.IsNullOrWhiteSpace(form.Description))
            {
                model.AddModelError("Form.Description", "Заполните поле");
            }

            if (string.IsNullOrWhiteSpace(form.Title))
            {
                model.AddModelError("Form.Title", "Заполните поле");
            }

            if (form.TicketCount <= 0)
            {
                model.AddModelError("Form.TicketCount", "Значение должно быть больше нуля");
            }

            if (DateTime.TryParse(form.IssueDate, out var date))
            {
                if(date.Date <= DateTime.Now.Date)
                    model.AddModelError("Form.IssueDate", "Некорректная дата");
            }
            else
            {
                model.AddModelError("Form.IssueDate", "Некорректная дата");
            }

            if (form.Duration <= 0)
            {
                model.AddModelError("Form.Duration", "Значение должно быть больше нуля");
            }

            if (form.TicketCost < 0)
            {
                model.AddModelError("Form.TicketCost", "Значение должно быть больше нуля");
            }
        }
    }
}