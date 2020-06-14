using System;
using System.Collections.Generic;
using System.Linq;
using OTS.DataLayer.Infrastructure;

namespace OTS.DataLayer.Entities.Events
{
    public class EventRepository : IEventRepository
    {
        private readonly IEntityRepository<IOtsEntity> entityRepository;

        public EventRepository(IEntityRepository<IOtsEntity> entityRepository)
        {
            this.entityRepository = entityRepository;
        }

        public IList<Event> All()
        {
            return entityRepository.GetTable<Event>().ToList();
        }

        public Event Find(Guid id)
        {
            return entityRepository.GetTable<Event>().FirstOrDefault(e => e.Id == id);
        }
    }
}