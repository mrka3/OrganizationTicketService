using System.Linq;
using OTS.DataLayer.Entities.Events;

namespace OTS.Administration.Models.Events.List
{
    public class EventListModelBuilder : IEventListModelBuilder
    {
        private readonly IEventRepository eventRepository;

        public EventListModelBuilder(IEventRepository eventRepository)
        {
            this.eventRepository = eventRepository;
        }

        public EventListModel Build(bool isAdmin)
        {
            var events = eventRepository.All();

            return new EventListModel(events.Select(e => new EventListItemModel(){Id = e.Id, TicketCount = $"{e.TicketCount}", Title = e.Title}).ToList(), isAdmin);
        }
    }
}