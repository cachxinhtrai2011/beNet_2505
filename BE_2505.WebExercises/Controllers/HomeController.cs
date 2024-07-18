using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BE_2505.WebExercises.Models;

namespace BE_2505.WebExercises.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<Product_Category> product_Categorys = new List<Product_Category>();
            ProductDBContext productDBContext = new ProductDBContext();
            product_Categorys = productDBContext.Product_Categorys.ToList();
            return View(product_Categorys);
        }

        [HttpPost]
        public JsonResult Create(Product_Category product_Category)
        {
            try
            {
                ProductDBContext productDBContext = new ProductDBContext();
                if (ModelState.IsValid)
                {
                    productDBContext.Product_Categorys.Add(product_Category);
                    productDBContext.SaveChanges();
                    return Json(new { success = true });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
            return Json(new { success = false });
        }
        [HttpPost]
        public JsonResult Search(string search)
        {
            ProductDBContext productDBContext = new ProductDBContext();
            List<Product_Category> product_Categorys = new List<Product_Category>();
            try
            {
                if (ModelState.IsValid)
                {
                    product_Categorys = productDBContext.Product_Categorys.ToList().Where(x => x.CategoryName.ToLower().Contains(search.ToLower())).ToList();
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
            return Json(new { success = true, data = product_Categorys });
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}