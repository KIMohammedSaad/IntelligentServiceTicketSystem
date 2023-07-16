using Microsoft.AspNetCore.Mvc;
using ServiceTicketRouter.Data;
using ServiceTicketRouter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceTicketRouter.Controllers
{
    public class ServicerViewAllTicketController : Controller
    {
        private readonly ServiceTicketDbContext context;
        public ServicerViewAllTicketController(ServiceTicketDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        [Route("/servicerViewAllTicket")]
        public IActionResult Index()
        {
            var AllSerTickets = context.TicketDetails.ToList();
            return View(AllSerTickets);

            //List<TicketDetail> AllSerTickets = context.TicketDetails.ToList<TicketDetail>();
            //List<TicketDetail> UserRequests = new List<TicketDetail>();
            //string UserName;
            //UserName = TempData.Peek("loggedInUsername").ToString();
            ////IssueType = TempData.Peek("loggedInUsername").ToString();
            //foreach (TicketDetail r in AllSerTickets)
            //{   

            //    if (r.ServicerName == UserName)
            //    {
                    
            //          UserRequests.Add(r);
            //    }
               
                
            //}
            //ViewBag.userTickets = UserRequests;
            //return View();
        }

    }
}
