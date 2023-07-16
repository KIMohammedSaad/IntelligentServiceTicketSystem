using Microsoft.AspNetCore.Mvc;
using ServiceTicketRouter.Data;
using ServiceTicketRouter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceTicketRouter.Controllers
{
    public class CustomerTicketStatusController : Controller
    {
        private readonly ServiceTicketDbContext context;
        public CustomerTicketStatusController(ServiceTicketDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        [Route("status/")]
        public IActionResult Index()
        {
            ViewBag.errorMessage = "";
            return View();
        }
        [HttpPost]
        [Route("status/")]
        public IActionResult Index(TicketDetail ticketdetails)
        {
            //TicketDetail ticketno = context.TicketDetails.FirstOrDefault(t => t.TicketNo == ticketdetails.TicketNo);
            //int id = Int32.Parse(TempData.Peek("TicketNo").ToString());
            //int id = Int32.Parse(ViewData.Peek("TicketNo").ToString());
            //int id = ViewData.["TicketNo"].ToString();


            if (ticketdetails.TicketNo == 10002)
            {
                ViewBag.errorMessage = "Invalid data";
                return View();

            }
            else
            {
                TempData["CusNewTicketNo"] = ticketdetails.TicketNo;
                return RedirectToAction("Index", "TicketDetails");
            }

        }
    }
}