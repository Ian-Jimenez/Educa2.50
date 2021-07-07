using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class ProfeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProfeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Profe
        public async Task<IActionResult> Index()
        {
            return View(await _context.Profe.ToListAsync());
        }

        // GET: Profe/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profe = await _context.Profe
                .FirstOrDefaultAsync(m => m.ProfeId == id);
            if (profe == null)
            {
                return NotFound();
            }

            return View(profe);
        }

        // GET: Profe/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Profe/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProfeId,Nombre,Telefono")] Profe profe)
        {
            if (ModelState.IsValid)
            {
                _context.Add(profe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(profe);
        }

        // GET: Profe/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profe = await _context.Profe.FindAsync(id);
            if (profe == null)
            {
                return NotFound();
            }
            return View(profe);
        }

        // POST: Profe/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProfeId,Nombre,Telefono")] Profe profe)
        {
            if (id != profe.ProfeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(profe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfeExists(profe.ProfeId))
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
            return View(profe);
        }

        // GET: Profe/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profe = await _context.Profe
                .FirstOrDefaultAsync(m => m.ProfeId == id);
            if (profe == null)
            {
                return NotFound();
            }

            return View(profe);
        }

        // POST: Profe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var profe = await _context.Profe.FindAsync(id);
            _context.Profe.Remove(profe);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfeExists(int id)
        {
            return _context.Profe.Any(e => e.ProfeId == id);
        }
    }
}
