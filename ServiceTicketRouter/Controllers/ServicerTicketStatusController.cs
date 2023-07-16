using Microsoft.AspNetCore.Mvc;
using ServiceTicketRouter.Data;
using ServiceTicketRouter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceTicketRouter.Controllers
{
    public class ServicerTicketStatusController : Controller
    {
        private readonly ServiceTicketDbContext context;
        public ServicerTicketStatusController(ServiceTicketDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        [Route("servicerTicketStatus/")]
        public IActionResult Index()
        {
            ViewBag.errorMessage = "";
            return View();
        }
        [HttpPost]
        [Route("servicerTicketStatus/")]
        public IActionResult Index(TicketDetail ticketdetails)
        {
            if (ticketdetails.TicketNo == 10001)
            {
                ViewBag.errorMessage = "Invalid data";
                return View();

            }
            else
            {
                TempData["newTicketNo"] = ticketdetails.TicketNo;
                return RedirectToAction("Index", "ServicerTicketDetails");
            }
        }
    }
}
