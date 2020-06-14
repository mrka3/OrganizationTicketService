using System;

namespace OTS.DataLayer.Entities.Users
{
    public interface IUserEventLinkFactory
    {
        UserEventLink Create(Guid userId, Guid eventId);
    }
}