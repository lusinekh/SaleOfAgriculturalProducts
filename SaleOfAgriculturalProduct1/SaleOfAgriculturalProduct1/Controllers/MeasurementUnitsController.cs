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
    public class MeasurementUnitsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MeasurementUnitsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MeasurementUnits
        public async Task<IActionResult> Index()
        {
            return View(await _context.MeasurementUnits.ToListAsync());
        }

        // GET: MeasurementUnits/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var measurementUnit = await _context.MeasurementUnits
                .FirstOrDefaultAsync(m => m.MeasurementUnitId == id);
            if (measurementUnit == null)
            {
                return NotFound();
            }

            return View(measurementUnit);
        }

        // GET: MeasurementUnits/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MeasurementUnits/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MeasurementUnitId,Unit")] MeasurementUnit measurementUnit)
        {
            if (ModelState.IsValid)
            {
                measurementUnit.MeasurementUnitId = Guid.NewGuid();
                _context.Add(measurementUnit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(measurementUnit);
        }

        // GET: MeasurementUnits/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var measurementUnit = await _context.MeasurementUnits.FindAsync(id);
            if (measurementUnit == null)
            {
                return NotFound();
            }
            return View(measurementUnit);
        }

        // POST: MeasurementUnits/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("MeasurementUnitId,Unit")] MeasurementUnit measurementUnit)
        {
            if (id != measurementUnit.MeasurementUnitId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(measurementUnit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MeasurementUnitExists(measurementUnit.MeasurementUnitId))
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
            return View(measurementUnit);
        }

        // GET: MeasurementUnits/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var measurementUnit = await _context.MeasurementUnits
                .FirstOrDefaultAsync(m => m.MeasurementUnitId == id);
            if (measurementUnit == null)
            {
                return NotFound();
            }

            return View(measurementUnit);
        }

        // POST: MeasurementUnits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var measurementUnit = await _context.MeasurementUnits.FindAsync(id);
            _context.MeasurementUnits.Remove(measurementUnit);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MeasurementUnitExists(Guid id)
        {
            return _context.MeasurementUnits.Any(e => e.MeasurementUnitId == id);
        }
    }
}
