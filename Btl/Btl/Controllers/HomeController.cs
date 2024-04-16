using Btl.Areas.Admin.Models.BusinessModels;
using Btl.Areas.Admin.Models.DataModels;
using Btl.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Btl.Controllers
{
    public class HomeController : Controller
    {
        private readonly BamaContext db;
        public HomeController(BamaContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            //var products = db.Products.Take(7).AsEnumerable();
            //return View(products);

            var viewModel = new Product();

            viewModel.Mesh = db.Products.Take(7).OrderBy(p => p.ProductId).ToList();
            viewModel.Arrivals = db.Products.Take(8).OrderByDescending(p => p.ProductId).ToList();

            return View(viewModel);
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Filter(int? CategoryId)
        {
            var data = db.Products.ToList();
            ViewBag.CategoryId = db.Categories.ToList();
            if(CategoryId != null)
            {
                data = db.Products.Where(c => c.CategoryId == CategoryId).ToList();
            }
            return View(data);
        }

        public IActionResult Detail(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var product = db.Products.FirstOrDefault(p => p.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        public IActionResult Register()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
