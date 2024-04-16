using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Btl.Areas.Admin.Models.BusinessModels;
using Btl.Areas.Admin.Models.DataModels;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Authorization;

namespace Btl.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ProductsController : Controller
    {
        private readonly BamaContext _context;

        public ProductsController(BamaContext context)
        {
            _context = context;
        }

        // GET: Admin/Products
        public async Task<IActionResult> Index(string keyword)
        {
            if(keyword != null)
            {
                var bamaContext = _context.Products.Where(x=>x.Name.Contains(keyword)).Include(p => p.Category);
                return View(await bamaContext.ToListAsync());
            }
            else
            {
                var bamaContext = _context.Products.Include(p => p.Category);
                return View(await bamaContext.ToListAsync());
            }
        }

        // GET: Admin/Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Admin/Products/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "Name");
            return View();
        }

        // POST: Admin/Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,Name,Image,Price,SalePrice,Description,CategoryId")] Product product, IFormFile ImageUpload)
        {
            if (ModelState.IsValid)
            {
                // xử lý upload ảnh
                if(ImageUpload != null || ImageUpload.Length > 0)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot", "images/products" + ImageUpload.FileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await ImageUpload.CopyToAsync(stream);
                    }
                    product.Image = "/images/products/" + ImageUpload.FileName;
                }

                _context.Add(product);
                await _context.SaveChangesAsync(); 
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "Name", product.CategoryId);
            return View(product);
        }

        // GET: Admin/Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
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
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "Name", product.CategoryId);
            return View(product);
        }

        // POST: Admin/Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,Name,Image,Price,SalePrice,Description,CategoryId")] Product product, IFormFile ImageFile)
        {
            if (id != product.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //var files = HttpContext.Request.Form.Files;
                    //if (files.Count() > 0 && files[0].Length > 0 )
                    //{
                    //    var file = files[0];
                    //    var FileName = file.FileName;
                    //    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot" + "images/products", FileName);
                    //    using(var stream = new FileStream(path, FileMode.Create))
                    //    {
                    //        file.CopyTo(stream);
                    //        product.Image = FileName;
                    //    }
                    //}
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ProductId))
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
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "Name", product.CategoryId);
            return View(product);
        }

        // GET: Admin/Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Admin/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.ProductId == id);
        }
    }
}
