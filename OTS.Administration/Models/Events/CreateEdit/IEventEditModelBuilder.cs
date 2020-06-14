using System;

namespace OTS.Administration.Models.Events.CreateEdit
{
    public interface IEventEditModelBuilder
    {
        EventEditModel BuildNew();
        EventEditModel BuildEdit(Guid id);
        EventEditModel BuildByForm(Guid? id, EventForm form);
    }
}