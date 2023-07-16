using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ServiceTicketRouter.Data;
using ServiceTicketRouter.Models;

namespace ServiceTicketRouter.Controllers
{
    public class ProfilesController : Controller
    {
        private readonly ServiceTicketDbContext _context;

        public ProfilesController(ServiceTicketDbContext context)
        {
            _context = context;
        }
        [Route("/profile")]
        // GET: Profiles
        public async Task<IActionResult> Index()
        {
            return View(await _context.Registers.ToListAsync());
        }

        // GET: Profiles/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var register = await _context.Registers
                .FirstOrDefaultAsync(m => m.Username == id);
            if (register == null)
            {
                return NotFound();
            }

            return View(register);
        }

        // GET: Profiles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Profiles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Username,Password,Name,Alias,Designation,Department,Email,Mobile,UserType,GroupId,Location")] Register register)
        {
            if (ModelState.IsValid)
            {
                _context.Add(register);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(register);
        }

        // GET: Profiles/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var register = await _context.Registers.FindAsync(id);
            if (register == null)
            {
                return NotFound();
            }
            return View(register);
        }

        // POST: Profiles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Username,Password,Name,Alias,Designation,Department,Email,Mobile,UserType,GroupId,Location")] Register register)
        {
            if (id != register.Username)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(register);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegisterExists(register.Username))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewBag.errorMessage = "Updated the details";
            return View(register);
        }

        // GET: Profiles/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var register = await _context.Registers
                .FirstOrDefaultAsync(m => m.Username == id);
            if (register == null)
            {
                return NotFound();
            }

            return View(register);
        }

        // POST: Profiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var register = await _context.Registers.FindAsync(id);
            _context.Registers.Remove(register);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegisterExists(string id)
        {
            return _context.Registers.Any(e => e.Username == id);
        }
    }
}
