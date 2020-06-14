using System;

namespace OTS.DataLayer.Entities.Events
{
    public class EventFactory : IEventFactory
    {
        public Event Create(string title, string description, int ticketCount, int duration, string issueDate)
        {
            return new Event()
            {
                Id = Guid.NewGuid(),
                Description = description,
                Title = title,
                TicketCount = ticketCount,
                Duration = duration,
                IssueDate = issueDate
            };
        }
    }
}