using System;
using System.IO;
using System.Threading.Tasks;
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

            return RedirectToAction("ItemService", "Event", new {id = eventId});
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var image = System.IO.File.OpenRead(Path.Combine(AppDomain.CurrentDomain.BaseDirectory ?? string.Empty, "Content", "qr-code.gif"));
            return File(image, "image/jpeg");
        }

    }
}