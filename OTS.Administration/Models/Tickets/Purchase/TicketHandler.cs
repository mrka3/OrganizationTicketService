using System;
using System.Net;
using OTS.DataLayer.Entities;
using OTS.DataLayer.Entities.Users;
using OTS.DataLayer.Infrastructure;

namespace OTS.Administration.Models.Tickets.Purchase
{
    public class TicketHandler : ITicketHandler
    {
        private readonly IUserEventLinkFactory userEventLinkFactory;
        private readonly IUserEventLinkRepository userEventLinkRepository;
        private readonly IEntityRepository<IOtsEntity> entityRepository;

        public TicketHandler(IUserEventLinkFactory userEventLinkFactory,
            IUserEventLinkRepository userEventLinkRepository, IEntityRepository<IOtsEntity> entityRepository)
        {
            this.userEventLinkFactory = userEventLinkFactory;
            this.userEventLinkRepository = userEventLinkRepository;
            this.entityRepository = entityRepository;
        }

        public void HandlePurchase(Guid eventId, Guid userId)
        {
            if (userEventLinkRepository.IsExist(userId, eventId)) return;

            var link = userEventLinkFactory.Create(userId, eventId);

            entityRepository.InsertOnSave(link);
            entityRepository.SaveChanges();
        }
    }
}