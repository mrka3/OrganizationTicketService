using System;

namespace OTS.Administration.Models.Tickets.Purchase
{
    public interface ITicketHandler
    {
        void HandlePurchase(Guid eventId, Guid userId);
    }
}