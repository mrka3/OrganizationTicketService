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
        public int TicketCost { get; set; }
        public IList<EventUsersModel> Visitors { get; set; }
        public bool CanBuyTicket { get; set; }

        public EventModel(Guid id, string title, string description, string issueDate, int ticketCount, int duration, int ticketCost, IList<EventUsersModel> visitors, bool canBuyTicket)
        {
            Id = id;
            Title = title;
            Description = description;
            IssueDate = issueDate;
            TicketCount = ticketCount;
            Duration = duration;
            TicketCost = ticketCost;
            Visitors = visitors;
            CanBuyTicket = canBuyTicket;
        }
    }
}