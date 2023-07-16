using Microsoft.AspNetCore.Mvc;
using ServiceTicketRouter.Data;
using ServiceTicketRouter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceTicketRouter.Controllers
{
    public class TicketDetailsController : Controller
    {
        private readonly ServiceTicketDbContext context;
        public TicketDetailsController(ServiceTicketDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        [Route("/ticketdetails")]
        public IActionResult Index()
        {
            ViewBag.errorMessage = "";
            var AllCusTickets = context.TicketDetails.ToList();
            return View(AllCusTickets);
        }
        [HttpPost]
        [Route("/ticketdetails")]
        public IActionResult Index(TicketDetail ticketdetails)
        {
            return RedirectToAction("Index", "ViewAllTicket");
        }
        
    }
}