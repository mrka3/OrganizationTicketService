using System;

namespace OTS.DataLayer.Entities.Events
{
    public interface IEventFactory
    {
        Event Create(string title, string description, int ticketCount, int duration, string issueDate);
    }
}