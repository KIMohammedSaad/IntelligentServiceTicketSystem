using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceTicketRouter.Data;
using ServiceTicketRouter.Models;
using System.Text.RegularExpressions;
using System.Net;
using System.Net.Sockets;

namespace ServiceTicketRouter.Controllers
{
    public class NewTicketRequestController : Controller
    {
        private readonly ServiceTicketDbContext context;
        public NewTicketRequestController(ServiceTicketDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        [Route("/newTicket")]
        public IActionResult Index()
        {
            ViewBag.errorMessage = "";
            return View();
        }
        [HttpPost]
        [Route("/newTicket")]
        public IActionResult Index(TicketDetail ticketdetail,Register register)
        {
            string iPAddress = ticketdetail.IPAddress;
            string str = iPAddress;
            bool ip_valid = false;
            //List<TicketDetail> AllTicket = context.TicketDetails.ToList<TicketDetail>();
            //List<TicketDetail> UserTicket = new List<TicketDetail>();

            if (iPAddress == null)
            {
                ViewBag.errorMessage = "Invalid data";
                return View();
            }
            else
            {
                string pattern = @"^\d{2}.\d{1,3}.\d{3}.\d{2,3}$";
                Regex reg = new Regex(pattern);

                //When pattern matches
                if (reg.IsMatch(iPAddress) == false)
                {
                    ViewBag.errorMessage = "Invalid data";
                    return View();

                }

                else
                {
                    int num = 10000;
                    num = context.TicketDetails.ToList().Count + 10000; ;
                    ticketdetail.TicketNo = num;
                    
                    switch (str.Substring(0, 7))
                    {
                        case "10.120.":
                        case "10.121.":
                        case "10.122.":
                        case "10.123.":
                        case "10.124.":
                        case "10.125.":
                        case "10.126.":
                            register.Location = "Gauteng";
                            ip_valid = true;
                            break;

                    }
                    switch (str.Substring(0, 5))
                    {
                        case "10.1.":
                        case "10.2.":
                        case "10.5.":
                        case "10.6.":
                        case "10.7.":
                        case "10.8.":
                        case "10.9.":
                            register.Location = "Paarl";
                            ip_valid = true;
                            break;
                    }
                    if (ip_valid == false)
                    {
                        ViewBag.errorMessage = "Invalid data";
                        return View();
                    }
                    else
                    {
                        switch (ticketdetail.IssueType)
                        {
                            case "Server":
                                register.GroupId = "AA01";
                                break;
                            case "Network":
                                register.GroupId = "AA02";
                                break;
                            case "Software":
                                register.GroupId = "AA03";
                                break;
                            case "Hardware":
                                register.GroupId = "AA04";
                                break;
                        }
                        //ticketdetail.TicketStatus = "Open";
                        TempData["TicketStatus"] = "Open";
                        ticketdetail.TicketStatus = TempData.Peek("TicketStatus").ToString();
                        //int tempTickNo = 0;
                        //TicketDetail ticketno = context.TicketDetails.FirstOrDefault(t=> t.TicketNo == ticketdetail.TicketNo);
                        TempData["TicketNo"] = ticketdetail.TicketNo;
                        ticketdetail.CustomerName = TempData.Peek("loggedInUsername").ToString();

                        //ticketdetail.TicketNo = Int32.Parse(TempData.Peek("TicketNo").ToString());

                        //TempData.Keep();
                        //foreach (TicketDetail tic in AllTicket)
                        //{
                        //    if (tic.TicketNo == (int)TempData.Peek("TicketNo"))
                        //    {
                        //        UserTicket.Add(tic);
                        //    }
                        //}
                        //int id = Int32.Parse(TempData.Peek("TicketNo").ToString());
                        //foreach (TicketDetail tic in AllTicket)
                        //{
                        //    if (tic.TicketNo == Int32.Parse(TempData.Peek("TicketNo").ToString()))
                        //    {
                        //        context.TicketDetails.Add(ticketdetail);
                        //    }
                        //}


                        context.TicketDetails.Add(ticketdetail);
                        context.SaveChanges();
                        return RedirectToAction("Index", "ViewAllTicket");

                    }
                }
            }

           

        }

    }
}