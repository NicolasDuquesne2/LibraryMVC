using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LibraryMVC.Data;
using LibraryMVC.Entities;

namespace LibraryMVC.Controllers
{
    public class LecteursController : Controller
    {
        private readonly LibraryDbContext _context;

        public LecteursController(LibraryDbContext context)
        {
            _context = context;
        }

        // GET: Lecteurs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Lecteurs.ToListAsync());
        }

        // GET: Lecteurs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lecteur = await _context.Lecteurs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lecteur == null)
            {
                return NotFound();
            }

            return View(lecteur);
        }

        // GET: Lecteurs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Lecteurs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MotDePasse,Nom,Prenom,Email,Telephone,Id")] Lecteur lecteur)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lecteur);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lecteur);
        }

        // GET: Lecteurs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lecteur = await _context.Lecteurs.FindAsync(id);
            if (lecteur == null)
            {
                return NotFound();
            }
            return View(lecteur);
        }

        // POST: Lecteurs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MotDePasse,Nom,Prenom,Email,Telephone,Id")] Lecteur lecteur)
        {
            if (id != lecteur.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lecteur);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LecteurExists(lecteur.Id))
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
            return View(lecteur);
        }

        // GET: Lecteurs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lecteur = await _context.Lecteurs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lecteur == null)
            {
                return NotFound();
            }

            return View(lecteur);
        }

        // POST: Lecteurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lecteur = await _context.Lecteurs.FindAsync(id);
            if (lecteur != null)
            {
                _context.Lecteurs.Remove(lecteur);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LecteurExists(int id)
        {
            return _context.Lecteurs.Any(e => e.Id == id);
        }
    }
}
