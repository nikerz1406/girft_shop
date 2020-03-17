using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Girft_shop.Models;

namespace Girft_shop.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            //load cart
            var cus = Session["cus"] as Girft_shop.ViewModel.CartVM;
            ViewBag.countCart = cus.count;
            ViewBag.totalCart = cus.amount;
            ViewData["cart"] = cus._cart;
            //end load
            var id = Request.Params["id"];
            if (id == null) return RedirectToAction("Index","Home");

            var pro = new girftEntities().products.ToList().Where(x => x.id.ToString() == id).FirstOrDefault();

            ViewBag.name = pro.name;
            ViewBag.description = pro.description;
            ViewBag.price = pro.price;
            ViewBag.img = pro.img;
            ViewBag.id = pro.id;
            ViewBag.dis = pro.price * 0.9;

            return View();
        }
    }
}