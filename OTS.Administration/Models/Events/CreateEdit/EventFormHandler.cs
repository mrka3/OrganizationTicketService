using System;
using OTS.DataLayer.Entities;
using OTS.DataLayer.Entities.Events;
using OTS.DataLayer.Infrastructure;

namespace OTS.Administration.Models.Events.CreateEdit
{
    public class EventFormHandler : IEventFormHandler
    {
        private readonly IEventFactory eventFactory;
        private readonly IEntityRepository<IOtsEntity> entityRepository;

        public EventFormHandler(IEventFactory eventFactory, IEntityRepository<IOtsEntity> entityRepository)
        {
            this.eventFactory = eventFactory;
            this.entityRepository = entityRepository;
        }

        public Guid HandleCreate(EventForm form)
        {
            var newEvent = eventFactory.Create(form.Title, form.Description, form.TicketCount, form.Duration, form.TicketCost,
                form.IssueDate);

            entityRepository.InsertOnSave(newEvent);
            entityRepository.SaveChanges();

            return newEvent.Id;
        }

        public void HandleEdit(EventForm form, EventValidationResult valResult)
        {
            valResult.Event.Title = form.Title;
            valResult.Event.Description = form.Description;
            valResult.Event.Duration = form.Duration;
            valResult.Event.IssueDate = form.IssueDate;
            valResult.Event.TicketCount = form.TicketCount;
            valResult.Event.TicketCost = form.TicketCost;

            entityRepository.SaveChanges();
        }


    }
}