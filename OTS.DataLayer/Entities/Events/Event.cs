using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace OTS.DataLayer.Entities.Events
{
    [Table("events")]
    public class Event : IOtsEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int TicketCount { get; set; }
        public int Duration { get; set; }
        public int TicketCost { get; set; }
        public string IssueDate { get; set; }

    }
}