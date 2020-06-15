using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OTS.Administration.Models.Tickets.Purchase;

namespace OTS.Administration.Controllers
{
    [Authorize]
    public class TicketController : Controller
    {
        private readonly ITicketHandler ticketHandler;

        public TicketController(ITicketHandler ticketHandler)
        {
            this.ticketHandler = ticketHandler;
        }

        [HttpGet]
        public IActionResult GetTicket(Guid eventId)
        {
            if (!Guid.TryParse(User.Identity.Name, out var userId)) throw new Exception("У вас нет доступа");

            ticketHandler.HandlePurchase(eventId, userId);

            return RedirectToAction("Item", "Event", new {id = eventId});
        }
    }
}