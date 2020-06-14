using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OTS.DataLayer.Entities.Events;

namespace OTS.DataLayer.Entities.Users
{
    [Table("user_event_links")]
    public class UserEventLink : IOtsEntity
    {
        public Guid UserId { get; set; }
        public Guid EventId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        [ForeignKey("EventId")]
        public virtual Event Event { get; set; }
    }
}