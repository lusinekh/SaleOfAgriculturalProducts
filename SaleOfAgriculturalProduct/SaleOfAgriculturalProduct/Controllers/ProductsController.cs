using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SaleOfAgriculturalProduct.Data;
using SaleOfAgriculturalProduct.Services;
using SaleOfAgriculturalProduct.Services.ProductItemService;
using System;
using Microsoft.AspNetCore.Authorization;

namespace SaleOfAgriculturalProduct.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IProductItmsService<Guid> _productItmsService;
        public ProductsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IProductItmsService<Guid> productItmsService)
        {
            _context = context;
            _userManager = userManager;
            _productItmsService = productItmsService;
        }

        // GET: Products
        public async Task<IActionResult> Index(string sort)
        {         
            var applicationDbContext = _context.Products.Include(p => p.ProductItmsImage);         

            if (sort == "countasc")
            {
              var e=  applicationDbContext.OrderBy(p => p.Count);
                return View(await e.ToListAsync());
            }
            if (sort == "Apple")
            {
                var e = applicationDbContext.Where(p => p.Category == "Apple").OrderBy(p=>p.Count).OrderBy(p=>p.PriceUnit).Select(X =>

                    new Product
                    {
                      Category=X.Category, 
                      MeasurementUnit=X.MeasurementUnit, 
                      PriceUnit=X.PriceUnit,
                      Count=X.Count, 
                      Quality=X.Quality,         
                      ProductionTime=X.ProductionTime, 
                      ProductItmsImageId=X.ProductItmsImageId,
                      ProductItmsImage=X.ProductItmsImage,
                      FirstName=X.FirstName, 
                      LastName=X.LastName, 
                      BirtDate=X.BirtDate, 
                      FhoneNamber=X.FhoneNamber, 
                      Adress=X.Adress    }
                    );
                return View(await e.ToListAsync());
            }
            return View(await applicationDbContext.ToListAsync());
        }

        public async Task<IActionResult> SortApple(string sort)
        {
            var applicationDbContext = _context.Products.Include(p => p.ProductItmsImage);
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
                    );
            return View("Index", await e.ToListAsync());
        }

        public async Task<IActionResult> SortApricote(string sort)
        {
            var applicationDbContext = _context.Products.Include(p => p.ProductItmsImage);
            var e = applicationDbContext.Where(p => p.Category == "Apricote").OrderBy(p => p.Count).OrderBy(p => p.PriceUnit).Select(X =>

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
                    );
            return View("Index", await e.ToListAsync());
        }
        public async Task<IActionResult> SortBananas(string sort)
        {
            var applicationDbContext = _context.Products.Include(p => p.ProductItmsImage);
            var e = applicationDbContext.Where(p => p.Category == "Bananas").OrderBy(p => p.Count).OrderBy(p => p.PriceUnit).Select(X =>

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
                    );
            return View("Index", await e.ToListAsync());
        }
        public async Task<IActionResult> SortWatermelon(string sort)
        {
            var applicationDbContext = _context.Products.Include(p => p.ProductItmsImage);
            var e = applicationDbContext.Where(p => p.Category == "Watermelon").OrderBy(p => p.Count).OrderBy(p => p.PriceUnit).Select(X =>

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
                    );
            return View("Index", await e.ToListAsync());
        }
        public async Task<IActionResult> SortCarrot(string sort)
        {
            var applicationDbContext = _context.Products.Include(p => p.ProductItmsImage);
            var e = applicationDbContext.Where(p => p.Category == "Carrot").OrderBy(p => p.Count).OrderBy(p => p.PriceUnit).Select(X =>

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
                    );
            return View("Index", await e.ToListAsync());
        }
        public async Task<IActionResult> SortPotato(string sort)
        {
            var applicationDbContext = _context.Products.Include(p => p.ProductItmsImage);
            var e = applicationDbContext.Where(p => p.Category == "Potato").OrderBy(p => p.Count).OrderBy(p => p.PriceUnit).Select(X =>

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
                    );
            return View("Index", await e.ToListAsync());
        }
        public async Task<IActionResult> SortGreens(string sort)
        {
            var applicationDbContext = _context.Products.Include(p => p.ProductItmsImage);
            var e = applicationDbContext.Where(p => p.Category == "Greens").OrderBy(p => p.Count).OrderBy(p => p.PriceUnit).Select(X =>

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
                    );
            return View("Index", await e.ToListAsync());
        }
        public async Task<IActionResult> SortBent(string sort)
        {
            var applicationDbContext = _context.Products.Include(p => p.ProductItmsImage);
            var e = applicationDbContext.Where(p => p.Category == "Bent").OrderBy(p => p.Count).OrderBy(p => p.PriceUnit).Select(X =>

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
                    );
            return View("Index", await e.ToListAsync());
        }
        // GET: Products/Details/5
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
        // GET: Products/Create
        [Authorize]
        public IActionResult Create()
        {
            ViewData["ProductItmsImageId"] = new SelectList(_context.ProductItmsImages, "ProductItmsImageId", "Exstention");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductID,Category,MeasurementUnit,PriceUnit,Count,Quality,ShowAllow,ProductionTime,ProductItmsImageId")] Product product)
        {
            if (ModelState.IsValid)
            {
                product.ProductID = Guid.NewGuid();
                var user = await _userManager.GetUserAsync(User);
                product.FirstName = user.FirstName;
                product.LastName = user.LastName;
                product.FhoneNamber = user.FhoneNamber;
                product.Adress = user.Adress;
                product.BirtDate = user.BirtDate;
                _context.Add(product);
                await _context.SaveChangesAsync();   


                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductItmsImageId"] = new SelectList(_context.ProductItmsImages, "ProductItmsImageId", "Exstention", product.ProductItmsImageId);
            return View(product);
        }

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
            ViewData["ProductItmsImageId"] = new SelectList(_context.ProductItmsImages, "ProductItmsImageId", "Exstention", product.ProductItmsImageId);
            return View(product);
        }

        // POST: Products/Edit/5
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

        // GET: Products/Delete/5
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
