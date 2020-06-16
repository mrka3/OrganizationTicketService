using System.Collections;
using System.Collections.Generic;

namespace OTS.Administration.Models.Events.List
{
    public class EventListModel
    {
        public IList<EventListItemModel> Events { get; set; }
        public bool IsAdmin { get; set; }

        public EventListModel(IList<EventListItemModel> events, bool isAdmin)
        {
            Events = events;
            IsAdmin = isAdmin;
        }
    }
}