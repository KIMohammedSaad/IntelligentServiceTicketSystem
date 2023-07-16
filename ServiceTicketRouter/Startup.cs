using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ServiceTicketRouter.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceTicketRouter.Models;

namespace ServiceTicketRouter
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddControllersWithViews();
            services.AddMvc(options => options.EnableEndpointRouting = false);

            services.AddDbContext<ServiceTicketDbContext>(options => {
                options.UseInMemoryDatabase(Configuration.GetConnectionString("DefaultConnection"));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllerRoute(
            //        name: "default",
            //        pattern: "{controller=Home}/{action=Index}/{id?}");
            //});
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
                routes.MapRoute(
                    name: "login",
                    template: "{controller=Login}/{action=Login}");
                routes.MapRoute(
                   name: "signup",
                   template: "{controller=SignUp}/{action=Index}");
                routes.MapRoute(
                    name: "customerRegister",
                    template: "{controller=CustomerRegister}/{action=Index}");
                routes.MapRoute(
                    name: "servicerRegister",
                    template: "{controller=ServicerRegister}/{action=Index}");
                routes.MapRoute(
                    name: "newTicketRequest",
                    template: "{controller=NewTicketRequest}/{action=Index}");
                routes.MapRoute(
                    name: "customerTicketStatus",
                    template: "{controller=CustomerTicketStatus}/{action=Index}");
                routes.MapRoute(
                    name: "ticketDetails",
                    template: "{controller=TicketDetails}/{action=Index}");
                routes.MapRoute(
                    name: "servicerTicketStatus",
                    template: "{controller=ServicerTicketStatus}/{action=Index}");
                routes.MapRoute(
                    name: "servicerTicketDetails",
                    template: "{controller=ServicerTicketDetails}/{action=Index}");
                routes.MapRoute(
                    name: "viewAllTicket",
                    template: "{controller=ViewAllTicket}/{action=Index}");
                routes.MapRoute(
                   name: "servicerViewAllTicket",
                   template: "{controller=ServicerViewAllTicket}/{action=Index}");
                routes.MapRoute(
                 name: "profile",
                 template: "{controller=Profile}/{action=Index}");
            });
       
            //var scope = app.ApplicationServices.CreateScope();
            //var context = scope.ServiceProvider.GetService<ServiceTicketDbContext>();
            //SeedData(context);
        }
    }
}
