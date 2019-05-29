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
    public class ProductItmsImagesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductItmsImagesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ProductItmsImages
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProductItmsImages.ToListAsync());
        }   

        // GET: ProductItmsImages/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productItmsImage = await _context.ProductItmsImages
                .FirstOrDefaultAsync(m => m.ProductItmsImageId == id);
            if (productItmsImage == null)
            {
                return NotFound();
            }

            return View(productItmsImage);
        }

        // GET: ProductItmsImages/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProductItmsImages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductItmsImageId,Path,ImageName,Size,Exstention")] ProductItmsImage productItmsImage)
        {
            if (ModelState.IsValid)
            {
                productItmsImage.ProductItmsImageId = Guid.NewGuid();
                _context.Add(productItmsImage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productItmsImage);
        }

        // GET: ProductItmsImages/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productItmsImage = await _context.ProductItmsImages.FindAsync(id);
            if (productItmsImage == null)
            {
                return NotFound();
            }
            return View(productItmsImage);
        }

        // POST: ProductItmsImages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ProductItmsImageId,Path,ImageName,Size,Exstention")] ProductItmsImage productItmsImage)
        {
            if (id != productItmsImage.ProductItmsImageId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productItmsImage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductItmsImageExists(productItmsImage.ProductItmsImageId))
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
            return View(productItmsImage);
        }

        // GET: ProductItmsImages/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productItmsImage = await _context.ProductItmsImages
                .FirstOrDefaultAsync(m => m.ProductItmsImageId == id);
            if (productItmsImage == null)
            {
                return NotFound();
            }

            return View(productItmsImage);
        }

        // POST: ProductItmsImages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var productItmsImage = await _context.ProductItmsImages.FindAsync(id);
            _context.ProductItmsImages.Remove(productItmsImage);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool ProductItmsImageExists(Guid id)
        {
            return _context.ProductItmsImages.Any(e => e.ProductItmsImageId == id);
        }
    }
}
