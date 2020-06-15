using System;

namespace OTS.Administration.Models.Events.CreateEdit
{
    public class EventForm
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string IssueDate { get; set; }
        public int TicketCount { get; set; }
        public int Duration { get; set; }
        public int TicketCost { get; set; }

        public EventForm()
        {
            IssueDate = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
        }
    }
}