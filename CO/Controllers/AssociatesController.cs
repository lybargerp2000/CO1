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
        private readonly COContext _context;

        public AssociatesController(COContext context)
        {
            _context = context;
        }

        // GET: Associates
        public async Task<IActionResult> Index()
        {
            return View(await _context.Associate.ToListAsync());
        }

        // GET: Associates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var associate = await _context.Associate
                .FirstOrDefaultAsync(m => m.Id == id);
            if (associate == null)
            {
                return NotFound();
            }

            return View(associate);
        }

        // GET: Associates/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Associates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdentityUserId,FirstName,LastName,Description")] Associate associate)
        {
            if (ModelState.IsValid)
            {
                _context.Add(associate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(associate);
        }

        // GET: Associates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var associate = await _context.Associate.FindAsync(id);
            if (associate == null)
            {
                return NotFound();
            }
            return View(associate);
        }

        // POST: Associates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdentityUserId,FirstName,LastName,Description")] Associate associate)
        {
            if (id != associate.Id)
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
                    if (!AssociateExists(associate.Id))
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
            return View(associate);
        }

        // GET: Associates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var associate = await _context.Associate
                .FirstOrDefaultAsync(m => m.Id == id);
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
            var associate = await _context.Associate.FindAsync(id);
            _context.Associate.Remove(associate);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AssociateExists(int id)
        {
            return _context.Associate.Any(e => e.Id == id);
        }
    }
}
