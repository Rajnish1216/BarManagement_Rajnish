using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BarManagement_Rajnish.Data;
using BarManagement_Rajnish.Models;

namespace BarManagement_Rajnish.Controllers
{
    public class WineBrandsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WineBrandsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: WineBrands
        public async Task<IActionResult> Index()
        {
            return View(await _context.WineBrands.ToListAsync());
        }

        // GET: WineBrands/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wineBrand = await _context.WineBrands
                .FirstOrDefaultAsync(m => m.ID == id);
            if (wineBrand == null)
            {
                return NotFound();
            }

            return View(wineBrand);
        }

        // GET: WineBrands/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WineBrands/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Price")] WineBrand wineBrand)
        {
            if (ModelState.IsValid)
            {
                _context.Add(wineBrand);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(wineBrand);
        }

        // GET: WineBrands/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wineBrand = await _context.WineBrands.FindAsync(id);
            if (wineBrand == null)
            {
                return NotFound();
            }
            return View(wineBrand);
        }

        // POST: WineBrands/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Price")] WineBrand wineBrand)
        {
            if (id != wineBrand.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(wineBrand);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WineBrandExists(wineBrand.ID))
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
            return View(wineBrand);
        }

        // GET: WineBrands/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wineBrand = await _context.WineBrands
                .FirstOrDefaultAsync(m => m.ID == id);
            if (wineBrand == null)
            {
                return NotFound();
            }

            return View(wineBrand);
        }

        // POST: WineBrands/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var wineBrand = await _context.WineBrands.FindAsync(id);
            _context.WineBrands.Remove(wineBrand);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WineBrandExists(int id)
        {
            return _context.WineBrands.Any(e => e.ID == id);
        }
    }
}
