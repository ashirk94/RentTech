using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RentTech.Data;
using RentTech.Models.DomainModels;

namespace RentTech.Controllers
{
    //only delete or edit items possible if done by owner user or admin
    public class TechItemsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TechItemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TechItems
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.TechItem.Include(t => t.Owner);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: TechItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var techItem = await _context.TechItem
                .Include(t => t.Owner)
                .FirstOrDefaultAsync(m => m.TechItemId == id);
            if (techItem == null)
            {
                return NotFound();
            }

            return View(techItem);
        }

        // GET: TechItems/Create
        public IActionResult Create()
        {
            ViewData["OwnerId"] = new SelectList(_context.Set<AppUser>(), "Id", "Id");
            return View();
        }

        // POST: TechItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TechItemId,Title,Description,Price,Condition,Type,RentDate,ReturnDate,OwnerId,Thumbnail,IsRented")] TechItem techItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(techItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OwnerId"] = new SelectList(_context.Set<AppUser>(), "Id", "Id", techItem.OwnerId);
            return View(techItem);
        }

        // GET: TechItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var techItem = await _context.TechItem.FindAsync(id);
            if (techItem == null)
            {
                return NotFound();
            }
            ViewData["OwnerId"] = new SelectList(_context.Set<AppUser>(), "Id", "Id", techItem.OwnerId);
            return View(techItem);
        }

        // POST: TechItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TechItemId,Title,Description,Price,Condition,Type,RentDate,ReturnDate,OwnerId,Thumbnail,IsRented")] TechItem techItem)
        {
            if (id != techItem.TechItemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(techItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TechItemExists(techItem.TechItemId))
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
            ViewData["OwnerId"] = new SelectList(_context.Set<AppUser>(), "Id", "Id", techItem.OwnerId);
            return View(techItem);
        }

        // GET: TechItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var techItem = await _context.TechItem
                .Include(t => t.Owner)
                .FirstOrDefaultAsync(m => m.TechItemId == id);
            if (techItem == null)
            {
                return NotFound();
            }

            return View(techItem);
        }

        // POST: TechItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var techItem = await _context.TechItem.FindAsync(id);
            _context.TechItem.Remove(techItem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TechItemExists(int id)
        {
            return _context.TechItem.Any(e => e.TechItemId == id);
        }
    }
}
