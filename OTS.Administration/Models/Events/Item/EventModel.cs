using System;
using System.Collections;
using System.Collections.Generic;

namespace OTS.Administration.Models.Events.Item
{
    public class EventModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string IssueDate { get; set; }
        public int TicketCount { get; set; }
        public int Duration { get; set; }
        public IList<EventUsersModel> Visitors { get; set; }

        public EventModel(Guid id, string title, string description, string issueDate, int ticketCount, int duration, IList<EventUsersModel> visitors)
        {
            Id = id;
            Title = title;
            Description = description;
            IssueDate = issueDate;
            TicketCount = ticketCount;
            Duration = duration;
            Visitors = visitors;
        }
    }
}