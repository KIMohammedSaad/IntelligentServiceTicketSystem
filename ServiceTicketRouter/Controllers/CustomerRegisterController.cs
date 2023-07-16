using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceTicketRouter.Models;
using ServiceTicketRouter.Data;

namespace ServiceTicketRouter.Controllers
{
    public class CustomerRegisterController : Controller
    {
        private readonly ServiceTicketDbContext context;
        public CustomerRegisterController(ServiceTicketDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        [Route("customerRegister/")]
        public IActionResult Index()
        {
            ViewBag.errorMessage = "";
            return View();
        }
        [HttpPost]
        [Route("customerRegister/")]
        public IActionResult Index(Register register)
        {
            
            if (register == null || register.Username == null || register.Password == null || register.Name == null || register.Alias == null
              || register.Designation == null || register.Department == null ||register.Email == null || register.Mobile == null  )
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

