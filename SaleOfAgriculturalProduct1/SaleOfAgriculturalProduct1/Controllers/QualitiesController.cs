using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SaleOfAgriculturalProduct1.Data;

namespace SaleOfAgriculturalProduct1.Controllers
{
    public class QualitiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public QualitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Qualities
        public async Task<IActionResult> Index()
        {
            return View(await _context.Qualitys.ToListAsync());
        }

        // GET: Qualities/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quality = await _context.Qualitys
                .FirstOrDefaultAsync(m => m.QualityId == id);
            if (quality == null)
            {
                return NotFound();
            }

            return View(quality);
        }

        // GET: Qualities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Qualities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("QualityId,QualityName")] Quality quality)
        {
            if (ModelState.IsValid)
            {
                quality.QualityId = Guid.NewGuid();
                _context.Add(quality);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(quality);
        }

        // GET: Qualities/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quality = await _context.Qualitys.FindAsync(id);
            if (quality == null)
            {
                return NotFound();
            }
            return View(quality);
        }

        // POST: Qualities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("QualityId,QualityName")] Quality quality)
        {
            if (id != quality.QualityId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(quality);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QualityExists(quality.QualityId))
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
            return View(quality);
        }

        // GET: Qualities/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quality = await _context.Qualitys
                .FirstOrDefaultAsync(m => m.QualityId == id);
            if (quality == null)
            {
                return NotFound();
            }

            return View(quality);
        }

        // POST: Qualities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var quality = await _context.Qualitys.FindAsync(id);
            _context.Qualitys.Remove(quality);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool QualityExists(Guid id)
        {
            return _context.Qualitys.Any(e => e.QualityId == id);
        }
    }
}
