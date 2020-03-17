using Girft_shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Girft_shop.Areas.Admin.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Admin/Products
        public ActionResult Index()
        {
            if (Session["user"] == null) return RedirectToAction("Index","Admin");

            return View();
        }

        public ActionResult ProductCate()
        {
            if (Session["user"] == null) return RedirectToAction("Index", "Admin");
            IList<product> LsProducts = new girftEntities().products.ToList();
            
            ViewData["products"] = LsProducts;
            return View();
        }
    }
}