using System;
using System.Collections.Generic;

namespace OTS.DataLayer.Entities.Users
{
    public interface IUserEventLinkRepository
    {
        IList<UserEventLink> AllByUserId(Guid id);
        IList<UserEventLink> AllByEventId(Guid id);
    }
}