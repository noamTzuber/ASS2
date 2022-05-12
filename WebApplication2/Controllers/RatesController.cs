using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LetsTalk.Models;
using WebApplication2.Data;

namespace WebApplication2.Controllers
{
    public class RatesController : Controller
    {
        private readonly WebApplication2Context _context;

        public RatesController(WebApplication2Context context)
        {
            _context = context;
        }

        // GET: Rates
        public async Task<IActionResult> Index()
        {
              return _context.Rate != null ? 
                          View(await _context.Rate.ToListAsync()) :
                          Problem("Entity set 'WebApplication2Context.Rate'  is null.");
        }

     
        public async Task<IActionResult> Index2(string query)
        {
            var q = _context.Rate.Where(rate=> rate.Name.Contains(query));

           return Json(await q.ToListAsync());
                        
        }

        [HttpPost]
        public async Task<IActionResult> Index(string query)
        {
            var q = _context.Rate.Where(rate => rate.Name.Contains(query));

            return Json(await q.ToListAsync());

        }
        // GET: Rates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Rate == null)
            {
                return NotFound();
            }

            var rate = await _context.Rate
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rate == null)
            {
                return NotFound();
            }

            return View(rate);
        }

        // GET: Rates/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Rates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,RateNum,Text")] Rate rate)
        {
            if (ModelState.IsValid)
            {
                rate.GetDate = DateTime.Now;    
                _context.Add(rate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rate);
        }

        // GET: Rates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Rate == null)
            {
                return NotFound();
            }

            var rate = await _context.Rate.FindAsync(id);
            if (rate == null)
            {
                return NotFound();
            }

            return View(rate);
        }

        // POST: Rates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,RateNum,Text")] Rate rate)
        {
            rate.GetDate = DateTime.Now;
            if (id != rate.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RateExists(rate.Id))
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
            return View(rate);
        }

        // GET: Rates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Rate == null)
            {
                return NotFound();
            }

            var rate = await _context.Rate
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rate == null)
            {
                return NotFound();
            }

            return View(rate);
        }

        // POST: Rates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Rate == null)
            {
                return Problem("Entity set 'WebApplication2Context.Rate'  is null.");
            }
            var rate = await _context.Rate.FindAsync(id);
            if (rate != null)
            {
                _context.Rate.Remove(rate);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RateExists(int id)
        {
          return (_context.Rate?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
