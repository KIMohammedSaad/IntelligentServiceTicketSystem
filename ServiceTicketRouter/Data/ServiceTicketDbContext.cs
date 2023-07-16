using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServiceTicketRouter.Models;

namespace ServiceTicketRouter.Data
{
    public class ServiceTicketDbContext :DbContext
    {
        public ServiceTicketDbContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<Register> Registers { get; set; }
        public DbSet<TicketDetail> TicketDetails { get; set; }
    }
}
