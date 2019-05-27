﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SaleOfAgriculturalProduct.Data;

namespace SaleOfAgriculturalProduct.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Products.Include(p => p.ProductItmsImage);

           
            {
                var e = applicationDbContext.Where(p => p.Category == "Apple").OrderBy(p => p.Count).OrderBy(p => p.PriceUnit).Select(X =>

                        new Product
                        {
                            Category = X.Category,
                            MeasurementUnit = X.MeasurementUnit,
                            PriceUnit = X.PriceUnit,
                            Count = X.Count,
                            Quality = X.Quality,
                            ProductionTime = X.ProductionTime,
                            ProductItmsImageId = X.ProductItmsImageId,
                            ProductItmsImage = X.ProductItmsImage,
                            FirstName = X.FirstName,
                            LastName = X.LastName,
                            BirtDate = X.BirtDate,
                            FhoneNamber = X.FhoneNamber,
                            Adress = X.Adress
                        }
                    ).Where(p => p.ShowAllow == false);
                return View(await e.ToListAsync());
            }
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Admin/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.ProductItmsImage)
                .FirstOrDefaultAsync(m => m.ProductID == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Admin/Create
        public IActionResult Create()
        {
            ViewData["ProductItmsImageId"] = new SelectList(_context.ProductItmsImages, "ProductItmsImageId", "Exstention");
            return View();
        }

        // POST: Admin/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductID,Category,MeasurementUnit,PriceUnit,Count,Quality,ShowAllow,ProductionTime,ProductItmsImageId,FirstName,LastName,BirtDate,FhoneNamber,Adress")] Product product)
        {
            if (ModelState.IsValid)
            {
                product.ProductID = Guid.NewGuid();
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductItmsImageId"] = new SelectList(_context.ProductItmsImages, "ProductItmsImageId", "Exstention", product.ProductItmsImageId);
            return View(product);
        }

        // GET: Admin/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["ProductItmsImageId"] = new SelectList(_context.ProductItmsImages, "ProductItmsImageId", "Exstention", product.ProductItmsImageId);
            return View(product);
        }

        // POST: Admin/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ProductID,Category,MeasurementUnit,PriceUnit,Count,Quality,ShowAllow,ProductionTime,ProductItmsImageId,FirstName,LastName,BirtDate,FhoneNamber,Adress")] Product product)
        {
            if (id != product.ProductID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ProductID))
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
            ViewData["ProductItmsImageId"] = new SelectList(_context.ProductItmsImages, "ProductItmsImageId", "Exstention", product.ProductItmsImageId);
            return View(product);
        }

        // GET: Admin/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.ProductItmsImage)
                .FirstOrDefaultAsync(m => m.ProductID == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var product = await _context.Products.FindAsync(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(Guid id)
        {
            return _context.Products.Any(e => e.ProductID == id);
        }
    }
}
