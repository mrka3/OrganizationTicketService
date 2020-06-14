using System;
using System.Collections.Generic;
using System.Linq;
using OTS.DataLayer.Infrastructure;

namespace OTS.DataLayer.Entities.Users
{
    public class UserEventLinkRepository : IUserEventLinkRepository
    {
        private readonly IEntityRepository<IOtsEntity> entityRepository;

        public UserEventLinkRepository(IEntityRepository<IOtsEntity> entityRepository)
        {
            this.entityRepository = entityRepository;
        }

        public IList<UserEventLink> AllByUserId(Guid id)
        {
            return entityRepository.GetTable<UserEventLink>().Where(ue => ue.UserId == id).ToList();
        }

        public IList<UserEventLink> AllByEventId(Guid id)
        {
            return entityRepository.GetTable<UserEventLink>().Where(ue => ue.EventId == id).ToList();
        }
    }
}