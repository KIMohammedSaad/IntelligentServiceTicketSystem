using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceTicketRouter.Models;
using ServiceTicketRouter.Data;

namespace ServiceTicketRouter.Controllers
{
    public class ServicerRegisterController : Controller
    {
        private ServiceTicketDbContext context;
        public ServicerRegisterController(ServiceTicketDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        [Route("servicerRegister/")]
        public IActionResult Index()
        {
            ViewBag.errorMessage = "";
            return View();
        }
        [HttpPost]
        [Route("servicerRegister/")]
        public IActionResult Index(Register register)
        {
            if (register.Username == null || register.Password == null || register.Name == null || 
              register.Email == null || register.Mobile == null || register.GroupId == null || register.Location == null )
              
              
            {
                ViewBag.errorMessage = "Invalid data";
                return View();
            }
            else if (register.GroupId != "AA01" && register.GroupId != "AA02" && register.GroupId != "AA03" &&
               register.GroupId != "AA04")
            {
                ViewBag.errorMessage = "Invalid data";
                return View();
            }
            else if (register.Location != "Gauteng" && register.Location != "Paarl")
            {
                ViewBag.errorMessage = "Invalid data";
                return View();
            }

            else 
               {
                try

                {
                    context.Registers.Add(register);
                    context.SaveChanges();
                    return RedirectToAction("Login", "Login");

                }
                catch (Exception ex)
                {
                    if (ex.HResult == -2147024809)
                    {
                        ViewBag.errorMessage = "Username already exists";
                        return View();
                    }

                }
                //context.Registers.Add(register);
                //context.SaveChanges();
                return RedirectToAction("Login", "Login");
            }
        }
    }
}
