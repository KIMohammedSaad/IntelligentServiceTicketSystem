using Microsoft.AspNetCore.Mvc;
using ServiceTicketRouter.Data;
using ServiceTicketRouter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceTicketRouter.Controllers
{
    public class ServicerTicketDetailsController : Controller
    {
        private readonly ServiceTicketDbContext context;
        public ServicerTicketDetailsController(ServiceTicketDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        [Route("servicerTicketDetails/")]
        public IActionResult Index()
        {
            ViewBag.errorMessage = "";
            return View();
        }
        [HttpPost]
        [Route("servicerTicketDetails/")]
        public IActionResult Index(TicketDetail ticketdetails)
        {
            //TempData["TicketStatusSer"] = ticketdetails.TicketStatus; 
            return RedirectToAction("Index", "ServicerViewAllTicket");
        }
    }
}

