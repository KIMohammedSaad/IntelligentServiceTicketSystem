using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceTicketRouter.Data;
using ServiceTicketRouter.Models;
using ServiceTicketRouter.Controllers;

namespace ServiceTicketRouter.Controllers
{
    public class LoginController : Controller
    {
        private ServiceTicketDbContext context;
        public LoginController(ServiceTicketDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        [Route("/login")]
        public IActionResult Login()
        {
            ViewBag.errorMessage = "";
            return View();
        }
        [HttpPost]
        [Route("/login")]
        public IActionResult Login(Register register, TicketDetail ticket)
        {
            
            if (register.Username == null || register.Password == null)
            {
                ViewBag.errorMessage = "Invalid credentials";
                return View();
            }
            else
            {

                Register user = context.Registers.FirstOrDefault(u => u.Username == register.Username && u.Password == register.Password);
                if (user == null)

                {
                    ViewBag.errorMessage = "Invalid credentials";
                    return View();
                }
                else
                    TempData["loggedInUsername"] = user.Username;
                    TempData["loggedInUsertype"] = user.UserType;
                    ticket.ServicerName = TempData.Peek("loggedInUsername").ToString();

                {
                    if (register.UserType == "Customer")
                    {
                        return RedirectToAction("Index", "NewTicketRequest");
                    }
                    else
                    {
                        return RedirectToAction("Index", "ServicerViewAllTicket");
                    }
                   
                }
            }
        }
    }
}
