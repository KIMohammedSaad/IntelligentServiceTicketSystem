using Microsoft.AspNetCore.Mvc;
using ServiceTicketRouter.Data;
using ServiceTicketRouter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceTicketRouter.Controllers
{
    public class ViewAllTicketController : Controller
    {
        private readonly ServiceTicketDbContext context;
        public ViewAllTicketController(ServiceTicketDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        [Route("/viewAllTicket")]
        public IActionResult Index()
        {
            //var AllCusTickets = context.TicketDetails.ToList();
            List<TicketDetail> AllCusTickets = context.TicketDetails.ToList<TicketDetail>();
            List<TicketDetail> UserRequests = new List<TicketDetail>();
            string UserName;
            UserName = TempData.Peek("loggedInUsername").ToString();
            
            foreach (TicketDetail r in AllCusTickets)
            {
               
                if (r.CustomerName == UserName)
                {
                    UserRequests.Add(r);
                }
            }
            ViewBag.userTickets = UserRequests;
            return View();
        }
    }
}
