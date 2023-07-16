using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceTicketRouter.Models;
using ServiceTicketRouter.Data;

namespace ServiceTicketRouter.Controllers
{
    public class SignUpController : Controller
    {
        private ServiceTicketDbContext context;
        public SignUpController(ServiceTicketDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        [Route("signUp/")]
        public IActionResult Index()
        {
            ViewBag.errorMessage = "";
            return View();
        }
        [HttpPost]
        [Route("signUp/")]
        
        public IActionResult Index(Register register)
        {
            
            String UserType = "Customer";
            if (register.UserType == UserType)
              
            {
                return RedirectToAction("Index", "CustomerRegister");
              
            }
            else
            {
                return RedirectToAction("Index", "ServicerRegister");
            }
            
            
        }
    }
}
