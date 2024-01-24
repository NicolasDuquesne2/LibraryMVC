using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LibraryMVC.Data;
using LibraryMVC.Entities;
using Microsoft.AspNetCore.Authorization;

namespace LibraryMVC.Controllers
{
    [Authorize]
    public class DomainesController : Controller
    {
        private readonly LibraryDbContext _context;

        public DomainesController(LibraryDbContext context)
        {
            _context = context;
        }

        // GET: Domaines
        public async Task<IActionResult> Index()
        {
            return View(await _context.Domaines.ToListAsync());
        }

        // GET: Domaines/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var domaine = await _context.Domaines
                .FirstOrDefaultAsync(m => m.Id == id);
            if (domaine == null)
            {
                return NotFound();
            }

            return View(domaine);
        }

        // GET: Domaines/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Domaines/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nom,Description,Id")] Domaine domaine)
        {
            if (ModelState.IsValid)
            {
                _context.Add(domaine);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(domaine);
        }

        // GET: Domaines/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var domaine = await _context.Domaines.FindAsync(id);
            if (domaine == null)
            {
                return NotFound();
            }
            return View(domaine);
        }

        // POST: Domaines/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Nom,Description,Id")] Domaine domaine)
        {
            if (id != domaine.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(domaine);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DomaineExists(domaine.Id))
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
            return View(domaine);
        }

        // GET: Domaines/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var domaine = await _context.Domaines
                .FirstOrDefaultAsync(m => m.Id == id);
            if (domaine == null)
            {
                return NotFound();
            }

            return View(domaine);
        }

        // POST: Domaines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var domaine = await _context.Domaines.FindAsync(id);
            if (domaine != null)
            {
                _context.Domaines.Remove(domaine);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DomaineExists(int id)
        {
            return _context.Domaines.Any(e => e.Id == id);
        }
    }
}
