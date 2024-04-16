using Btl.Areas.Admin.Models.BusinessModels;
using Btl.Areas.Admin.Models.DataModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Btl.Controllers
{
    public class CartController : Controller
    {
        private readonly BamaContext _context;
        private List<Cart> carts { get; set; } = new List<Cart>();
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var cartInSession = HttpContext.Session.GetString("My-Cart"); // dữ liệu lưu trong session 
            if (cartInSession != null)
            {
                // nếu session không null gán dữ liệu cho biến carts 
                // chuyển đổi chuỗi json => đối tượng List<Cart> phù hợp 
                carts = JsonConvert.DeserializeObject<List<Cart>>(cartInSession);
            }
            //base OnActionExecuting(context);
        }
        public CartController(BamaContext context)
        {
            _context = context;
        }

        public double CalculateTotal(List<Cart> carts)
        {
            double total = 0;
            foreach (var item in carts)
            {
                total += item.Price * item.Quantity;
            }
            return total;
        }

        public IActionResult Index()
        {
            return View(carts);
        }

        public IActionResult AddToCart(int id)
        {
            if (carts.Any(c => c.ProductId == id)) // nếu đã có sp trong giỏ hàng 
            {
                carts.Where(c => c.ProductId == id).First().Quantity += 1; // tìm và tăng số lượng 
            }
            else
            {
                // nếu chưa có trong giỏ hàng 
                var pro = _context.Products.Find(id);
                // khởi tạo đối tượng từ model cart và gán thông tin cho các thuộc tính 
                var Item = new Cart()
                {
                    ProductId = id,
                    ProductName = pro.Name,
                    Quantity = 1,
                    Price = pro.Price,
                    Image = pro.Image
                };
                carts.Add(Item); // thêm vào List<Cart>
            }
            // lưu vào session cần phải chuyển đổi List<Cart> sang chuỗi Json 
            HttpContext.Session.SetString("My-Cart", JsonConvert.SerializeObject(carts));
            return RedirectToAction("Index", "Cart");
        }

        public IActionResult Update(int id, int quantity)
        {
            if (carts.Any(c => c.ProductId == id))
            {
                var item = carts.Where(c => c.ProductId == id).First().Quantity = quantity;
                HttpContext.Session.SetString("My-Cart", JsonConvert.SerializeObject(carts));
            }
            return RedirectToAction("Index", "Cart");
        }

        public IActionResult RemoveItem(int id)
        {
            if (carts.Any(c => c.ProductId == id))
            {
                var item = carts.Where(c => c.ProductId == id).First();
                carts.Remove(item);
                HttpContext.Session.SetString("My-Cart", JsonConvert.SerializeObject(carts));
            }
            return RedirectToAction("Index", "Cart");
        }

        public IActionResult Clear()
        {
            HttpContext.Session.Remove("My-Cart");
            return RedirectToAction("Index", "Cart");
        }
    }
}
