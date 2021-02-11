using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using majorproject.Data;
using majorproject.Models;
using Microsoft.AspNetCore.Authorization;

namespace majorproject.Controllers
{
    [Authorize]
    public class SellsController : Controller
    {
        private readonly majorprojectContext _context;

        public SellsController(majorprojectContext context)
        {
            _context = context;
        }

        // GET: Sells
        public async Task<IActionResult> Index()
        {
            var majorprojectContext = _context.Sells.Include(s => s.Customers).Include(s => s.Location).Include(s => s.Products).Include(s => s.Staffs);
            return View(await majorprojectContext.ToListAsync());
        }

        // GET: Sells/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sells = await _context.Sells
                .Include(s => s.Customers)
                .Include(s => s.Location)
                .Include(s => s.Products)
                .Include(s => s.Staffs)
                .FirstOrDefaultAsync(m => m.id == id);
            if (sells == null)
            {
                return NotFound();
            }

            return View(sells);
        }

        // GET: Sells/Create
        public IActionResult Create()
        {
            ViewData["Customersid"] = new SelectList(_context.Customers, "id", "id");
            ViewData["Locationid"] = new SelectList(_context.Location, "id", "id");
            ViewData["Productsid"] = new SelectList(_context.Products, "id", "id");
            ViewData["StaffsId"] = new SelectList(_context.Staffs, "id", "id");
            return View();
        }

        // POST: Sells/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Productsid,Customersid,Locationid,StaffsId")] Sells sells)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sells);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Customersid"] = new SelectList(_context.Customers, "id", "id", sells.Customersid);
            ViewData["Locationid"] = new SelectList(_context.Location, "id", "id", sells.Locationid);
            ViewData["Productsid"] = new SelectList(_context.Products, "id", "id", sells.Productsid);
            ViewData["StaffsId"] = new SelectList(_context.Staffs, "id", "id", sells.StaffsId);
            return View(sells);
        }

        // GET: Sells/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sells = await _context.Sells.FindAsync(id);
            if (sells == null)
            {
                return NotFound();
            }
            ViewData["Customersid"] = new SelectList(_context.Customers, "id", "id", sells.Customersid);
            ViewData["Locationid"] = new SelectList(_context.Location, "id", "id", sells.Locationid);
            ViewData["Productsid"] = new SelectList(_context.Products, "id", "id", sells.Productsid);
            ViewData["StaffsId"] = new SelectList(_context.Staffs, "id", "id", sells.StaffsId);
            return View(sells);
        }

        // POST: Sells/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Productsid,Customersid,Locationid,StaffsId")] Sells sells)
        {
            if (id != sells.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sells);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SellsExists(sells.id))
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
            ViewData["Customersid"] = new SelectList(_context.Customers, "id", "id", sells.Customersid);
            ViewData["Locationid"] = new SelectList(_context.Location, "id", "id", sells.Locationid);
            ViewData["Productsid"] = new SelectList(_context.Products, "id", "id", sells.Productsid);
            ViewData["StaffsId"] = new SelectList(_context.Staffs, "id", "id", sells.StaffsId);
            return View(sells);
        }

        // GET: Sells/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sells = await _context.Sells
                .Include(s => s.Customers)
                .Include(s => s.Location)
                .Include(s => s.Products)
                .Include(s => s.Staffs)
                .FirstOrDefaultAsync(m => m.id == id);
            if (sells == null)
            {
                return NotFound();
            }

            return View(sells);
        }

        // POST: Sells/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sells = await _context.Sells.FindAsync(id);
            _context.Sells.Remove(sells);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SellsExists(int id)
        {
            return _context.Sells.Any(e => e.id == id);
        }
    }
}
