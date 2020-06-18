using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CO.Data;
using CO.Models;

namespace CO.Controllers
{
    public class AssociatesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AssociatesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Associates
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Associates.Include(a => a.IdentityUser);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Associates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var associate = await _context.Associates
                .Include(a => a.IdentityUser)
                .FirstOrDefaultAsync(m => m.AssociateId == id);
            if (associate == null)
            {
                return NotFound();
            }

            return View(associate);
        }

        // GET: Associates/Create
        public IActionResult Create()
        {
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Associates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AssociateId,IdentityUserId,FirstName,LastName,Description")] Associate associate)
        {
            if (ModelState.IsValid)
            {
                _context.Add(associate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", associate.IdentityUserId);
            return View(associate);
        }

        // GET: Associates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var associate = await _context.Associates.FindAsync(id);
            if (associate == null)
            {
                return NotFound();
            }
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", associate.IdentityUserId);
            return View(associate);
        }

        // POST: Associates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AssociateId,IdentityUserId,FirstName,LastName,Description")] Associate associate)
        {
            if (id != associate.AssociateId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(associate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssociateExists(associate.AssociateId))
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
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", associate.IdentityUserId);
            return View(associate);
        }

        // GET: Associates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var associate = await _context.Associates
                .Include(a => a.IdentityUser)
                .FirstOrDefaultAsync(m => m.AssociateId == id);
            if (associate == null)
            {
                return NotFound();
            }

            return View(associate);
        }

        // POST: Associates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var associate = await _context.Associates.FindAsync(id);
            _context.Associates.Remove(associate);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AssociateExists(int id)
        {
            return _context.Associates.Any(e => e.AssociateId == id);
        }
    }
}
