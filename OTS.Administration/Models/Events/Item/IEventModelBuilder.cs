using System;

namespace OTS.Administration.Models.Events.Item
{
    public interface IEventModelBuilder
    {
        EventModel Build(Guid id);
    }
}