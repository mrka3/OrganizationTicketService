using System;

namespace OTS.DataLayer.Entities.Users
{
    public class UserEventLinkFactory : IUserEventLinkFactory
    {
        public UserEventLink Create(Guid userId, Guid eventId)
        {
            return new UserEventLink()
            {
                UserId = userId,
                EventId = eventId
            };
        }
    }
}