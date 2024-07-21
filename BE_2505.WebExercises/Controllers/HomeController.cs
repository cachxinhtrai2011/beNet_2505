using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BE_2505.Common.Validate;
using BE2505.DataAccess.DALImplement;
using BE2505.DataAccess.DTO;

namespace BE_2505.WebExercises.Controllers
{
    public class HomeController : Controller
    {
        ProductManager productManager = new ProductManager();
        public ActionResult Index()
        {
            var productList = productManager.GetListProduct();
            return View(productList);
        }

        [HttpPost]
        public JsonResult InsertProduct(Product_Practice product_Practice)
        {
            ReturnData returnDataInsert = new ReturnData();
            try
            {
                if (ModelState.IsValid)
                {
                    returnDataInsert = productManager.Product_Insert(product_Practice);
                    if(returnDataInsert.ResponseCode == 1)
                    {
                        return Json(new { success = true, message = returnDataInsert.ResponseMessage });
                    }
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = returnDataInsert.ResponseMessage });
            }
            return Json(new { success = false, message = returnDataInsert.ResponseMessage });
        }
        [HttpPost]
        public JsonResult UpdateProduct(Product_Practice product_Practice)
        {
            ReturnData returnDataUpdate = new ReturnData();
            try
            {
                if (ModelState.IsValid)
                {
                    returnDataUpdate = productManager.Product_Update(product_Practice);
                    if (returnDataUpdate.ResponseCode == 1)
                    {
                        return Json(new { success = true, message = returnDataUpdate.ResponseMessage });
                    }
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = returnDataUpdate.ResponseMessage });
            }
            return Json(new { success = false, message = returnDataUpdate.ResponseMessage });
        }
        [HttpPost]
        public JsonResult DeleteProduct(Product_Practice product_Practice)
        {
            ReturnData returnDataDelete = new ReturnData();
            try
            {
                if (ModelState.IsValid)
                {
                    returnDataDelete = productManager.Product_Delete(product_Practice);
                    if (returnDataDelete.ResponseCode == 1)
                    {
                        return Json(new { success = true, message = returnDataDelete.ResponseMessage });
                    }
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = returnDataDelete.ResponseMessage });
            }
            return Json(new { success = false, message = returnDataDelete.ResponseMessage });
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