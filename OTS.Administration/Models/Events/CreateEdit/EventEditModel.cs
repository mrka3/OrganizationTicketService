using System;

namespace OTS.Administration.Models.Events.CreateEdit
{
    public class EventEditModel
    {
        public Guid? Id { get; set; }
        public EventForm Form { get; set; }

        public EventEditModel(Guid? id, EventForm form)
        {
            Id = id;
            Form = form;
        }
    }
}