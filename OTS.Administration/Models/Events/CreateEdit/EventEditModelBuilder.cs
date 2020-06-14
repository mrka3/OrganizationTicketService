using System;
using OTS.DataLayer.Entities.Events;

namespace OTS.Administration.Models.Events.CreateEdit
{
    public class EventEditModelBuilder : IEventEditModelBuilder
    {
        private readonly IEventRepository eventRepository;

        public EventEditModelBuilder(IEventRepository eventRepository)
        {
            this.eventRepository = eventRepository;
        }

        public EventEditModel BuildNew()
        {
            return new EventEditModel(null, new EventForm());
        }

        public EventEditModel BuildEdit(Guid id)
        {
            var eventModel = eventRepository.Find(id);

            if (eventModel == null) throw new Exception("Мероприятие не найдено");

            return new EventEditModel(id, new EventForm()
                {
                    Title = eventModel.Title,
                    Description = eventModel.Description,
                    IssueDate  = eventModel.IssueDate,
                    Duration = eventModel.Duration,
                    TicketCount = eventModel.TicketCount
                });
        }

        public EventEditModel BuildByForm(Guid? id, EventForm form)
        {
            return new EventEditModel(id, form);
        }
    }
}