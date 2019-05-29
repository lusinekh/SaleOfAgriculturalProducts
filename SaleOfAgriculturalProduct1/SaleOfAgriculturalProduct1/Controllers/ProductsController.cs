﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SaleOfAgriculturalProduct1.Data;

namespace SaleOfAgriculturalProduct1.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public ProductsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }        

        public async Task<IActionResult> Index(string sort)
        {
            var applicationDbContext = _context.Products.Include(p => p.Category).Include(p => p.MeasureUnit).Include(p => p.ProductItmsImage).Include(p => p.Qualitys).Where(p=>p.ShowAllow==true);
            var e = await _context.Categorys.ToListAsync();
            ProducCategoryview c;
            IEnumerable<Product> items = Enumerable.Empty<Product>();           
            if (sort != null)
            {
                foreach (var ep in e)
                {
                    if (sort  == ep.CategoryName)
                    {
                        items = applicationDbContext.Where(p => p.Category.CategoryName== ep.CategoryName);                       
                        break;
                    }
                }
                c = new ProducCategoryview
                {
                    Products = items,
                    Categorys = e
                };
            }
            else
            {
                c = new ProducCategoryview
                {
                    Products = applicationDbContext,
                    Categorys = e
                };
            }
           return View(c);
        }
        [Authorize]
        public async Task<IActionResult> UserAddProducts()
        {
            var user = await _userManager.GetUserAsync(User);
            var applicationDbContext = _context.Products.Include(p => p.Category).Include(p => p.MeasureUnit).Include(p => p.ProductItmsImage).Include(p => p.Qualitys).Where(p => p.ShowAllow == true).Where(p => p.ApplicationUserGuid == user.Id); 
           
            return View(applicationDbContext);
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Category)
                .Include(p => p.MeasureUnit)
                .Include(p => p.ProductItmsImage)
                .Include(p => p.Qualitys)
                .FirstOrDefaultAsync(m => m.ProductID == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        [Authorize]
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categorys, "CategoryId", "CategoryName");
            ViewData["MeasurementUnitId"] = new SelectList(_context.MeasurementUnits, "MeasurementUnitId", "Unit");
            ViewData["ProductItmsImageId"] = new SelectList(_context.ProductItmsImages, "ProductItmsImageId", "Exstention");
            ViewData["QualityId"] = new SelectList(_context.Qualitys, "QualityId", "QualityName");
            return View();
        }

        // POST: SaleOfAgriculturalProduct/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductID,PriceUnit,Count,ShowAllow,ProductionTime,ProductItmsImageId,CategoryId,MeasurementUnitId,QualityId")] Product product)
        //public async Task<IActionResult> Create([Bind("ProductID,PriceUnit,Count,ShowAllow,ProductionTime,ProductItmsImageId,CategoryId,MeasurementUnitId,QualityId,FirstName,LastName,FhoneNamber,Adress,ApplicationUserGuid")] Product product)
        {
            if (ModelState.IsValid)
            {
                product.ProductID = Guid.NewGuid();
                var user = await _userManager.GetUserAsync(User);
                product.FirstName = user.FirstName;
                product.LastName = user.LastName;
                product.FhoneNamber = user.FhoneNamber;
                product.Adress = user.Adress;
                product.ShowAllow = true;
                product.ApplicationUserGuid = user.Id;
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categorys, "CategoryId", "CategoryName", product.CategoryId);
            ViewData["MeasurementUnitId"] = new SelectList(_context.MeasurementUnits, "MeasurementUnitId", "Unit", product.MeasurementUnitId);
            ViewData["ProductItmsImageId"] = new SelectList(_context.ProductItmsImages, "ProductItmsImageId", "Exstention", product.ProductItmsImageId);
            ViewData["QualityId"] = new SelectList(_context.Qualitys, "QualityId", "QualityName", product.QualityId);
            return View(product); }    

        // GET: Products/Edit/5
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
            ViewData["CategoryId"] = new SelectList(_context.Categorys, "CategoryId", "CategoryName", product.CategoryId);
            ViewData["MeasurementUnitId"] = new SelectList(_context.MeasurementUnits, "MeasurementUnitId", "Unit", product.MeasurementUnitId);
            ViewData["ProductItmsImageId"] = new SelectList(_context.ProductItmsImages, "ProductItmsImageId", "Exstention", product.ProductItmsImageId);
            ViewData["QualityId"] = new SelectList(_context.Qualitys, "QualityId", "QualityName", product.QualityId);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ProductID,PriceUnit,Count,ShowAllow,ProductionTime,ProductItmsImageId,CategoryId,MeasurementUnitId,QualityId,FirstName,LastName,FhoneNamber,Adress,ApplicationUserGuid")] Product product)
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
            ViewData["CategoryId"] = new SelectList(_context.Categorys, "CategoryId", "CategoryName", product.CategoryId);
            ViewData["MeasurementUnitId"] = new SelectList(_context.MeasurementUnits, "MeasurementUnitId", "Unit", product.MeasurementUnitId);
            ViewData["ProductItmsImageId"] = new SelectList(_context.ProductItmsImages, "ProductItmsImageId", "Exstention", product.ProductItmsImageId);
            ViewData["QualityId"] = new SelectList(_context.Qualitys, "QualityId", "QualityName", product.QualityId);
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Category)
                .Include(p => p.MeasureUnit)
                .Include(p => p.ProductItmsImage)
                .Include(p => p.Qualitys)
                .FirstOrDefaultAsync(m => m.ProductID == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
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
