using Girft_shop.Models;
using Girft_shop.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Girft_shop.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.MenuHome = "active";

            if (Session["cus"] == null)
            {
                // new cart 
                CartVM cus = new CartVM();
                Session["cus"] = cus;
            }
            

            var getPro = new ProductsVM();

            // get data teddy
            ViewData["teddyPro"] = getPro.Teddy("GẤU TEDDY TRƠN");
            // get data animal
            ViewData["animal"] = getPro.Teddy("Heo bông");

            return View();
        }

        public JsonResult productsChange()
        {
            String str = Request.Params["filter"];
            char[] spearator = { '-' };
            var arr = str.Split(spearator);

            var isNumeric = int.TryParse(arr[1], out int n);

            if (!isNumeric) return Json(null, JsonRequestBehavior.AllowGet);

            var getPro = new ProductsVM();

            switch (arr[0])
            {
                case "G":
                    var data = new List<SubProducts>();
                    switch (arr[1])
                    {
                        case "1":
                            data = getPro.Teddy("GẤU TEDDY TRƠN");
                            break;
                        case "2":
                            data = getPro.Teddy("GẤU TEDDY ÁO LEN");
                            break;
                        default:
                            data = getPro.Teddy("GẤU TEDDY ÔM TIM");
                            break;
                    }
                    return Json(data, JsonRequestBehavior.AllowGet);
                case "T":
                    switch (arr[1])
                    {
                        case "1":
                            data = getPro.Teddy("Heo bông");
                            break;
                        case "2":
                            data = getPro.Teddy("Thỏ bông");
                            break;
                        case "3":
                            data = getPro.Teddy("Chó bông");
                            break;
                        default:
                            data = getPro.Teddy("Mèo bông");
                            break;
                    }
                    return Json(data, JsonRequestBehavior.AllowGet);
                default:
                    return Json(null, JsonRequestBehavior.AllowGet);

            }

            return Json(null, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Login()
        {
            //load cart
            var cus = Session["cus"] as Girft_shop.ViewModel.CartVM;
            ViewBag.countCart = cus.count;
            ViewBag.totalCart = cus.amount;
            ViewData["cart"] = cus._cart;
            //end load

            ViewBag.Message = "Login page.";

            return View();
        }

        public ActionResult Register()
        {
            //load cart
            var cus = Session["cus"] as Girft_shop.ViewModel.CartVM;
            ViewBag.countCart = cus.count;
            ViewBag.totalCart = cus.amount;
            ViewData["cart"] = cus._cart;
            //end load

            ViewBag.Message = "Register page.";

            return View();
        }

        public ActionResult Contact()
        {
            //load cart
            var cus = Session["cus"] as Girft_shop.ViewModel.CartVM;
            ViewBag.countCart = cus.count;
            ViewBag.totalCart = cus.amount;
            ViewData["cart"] = cus._cart;
            //end load

            ViewBag.Message = "Register page.";

            return View();
        }


    }
}