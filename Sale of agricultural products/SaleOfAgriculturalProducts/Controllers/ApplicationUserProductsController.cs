using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SaleOfAgriculturalProducts.Data;

namespace SaleOfAgriculturalProducts.Controllers
{
    public class ApplicationUserProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ApplicationUserProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ApplicationUserProducts
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ApplicationUserProducts.Include(a => a.Products);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ApplicationUserProducts/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationUserProduct = await _context.ApplicationUserProducts
                .Include(a => a.Products)
                .FirstOrDefaultAsync(m => m.ApplicationUserId == id);
            if (applicationUserProduct == null)
            {
                return NotFound();
            }

            return View(applicationUserProduct);
        }

        // GET: ApplicationUserProducts/Create
        public IActionResult Create()
        {
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductID", "Category");
            return View();
        }

        // POST: ApplicationUserProducts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ApplicationUserId,ProductId")] ApplicationUserProduct applicationUserProduct)
        {
            if (ModelState.IsValid)
            {
                //applicationUserProduct.ApplicationUserId =                  
                //    Guid.NewGuid();
                _context.Add(applicationUserProduct);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductID", "Category", applicationUserProduct.ProductId);
            ViewData["ApplicationUserId"] = new SelectList(_context.Products, "ApplicationUserId", "FirstName", applicationUserProduct.ApplicationUserId);

            return View(applicationUserProduct);
        }

        // GET: ApplicationUserProducts/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationUserProduct = await _context.ApplicationUserProducts.FindAsync(id);
            if (applicationUserProduct == null)
            {
                return NotFound();
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductID", "Category", applicationUserProduct.ProductId);
            return View(applicationUserProduct);
        }

        // POST: ApplicationUserProducts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ApplicationUserId,ProductId")] ApplicationUserProduct applicationUserProduct)
        {
            if (id != applicationUserProduct.ApplicationUserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(applicationUserProduct);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApplicationUserProductExists(applicationUserProduct.ApplicationUserId))
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
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductID", "Category", applicationUserProduct.ProductId);
            return View(applicationUserProduct);
        }

        // GET: ApplicationUserProducts/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationUserProduct = await _context.ApplicationUserProducts
                .Include(a => a.Products)
                .FirstOrDefaultAsync(m => m.ApplicationUserId == id);
            if (applicationUserProduct == null)
            {
                return NotFound();
            }

            return View(applicationUserProduct);
        }

        // POST: ApplicationUserProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var applicationUserProduct = await _context.ApplicationUserProducts.FindAsync(id);
            _context.ApplicationUserProducts.Remove(applicationUserProduct);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApplicationUserProductExists(Guid id)
        {
            return _context.ApplicationUserProducts.Any(e => e.ApplicationUserId == id);
        }
    }
}
