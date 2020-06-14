using System;
using System.Collections.Generic;

namespace OTS.DataLayer.Entities.Events
{
    public interface IEventRepository
    {
        IList<Event> All();
        Event Find(Guid id);
    }
}