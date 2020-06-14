using System;

namespace OTS.Administration.Models.Events.List
{
    public class EventListItemModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string TicketCount { get; set; }
    }
}