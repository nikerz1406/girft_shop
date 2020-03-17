using Girft_shop.Models;
using Girft_shop.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Girft_shop.Controllers
{
    public class ShopController : Controller
    {
        // GET: Shop
        public ActionResult Index()
        {
            //load cart
            var cus = Session["cus"] as Girft_shop.ViewModel.CartVM;
            ViewBag.countCart = cus.count;
            ViewBag.totalCart = cus.amount;
            ViewData["cart"] = cus._cart;
            //end load
            ViewBag.Menu = 1;

            return View();
        }

        public ActionResult ShopCart()
        {
            //load cart
            var cus = Session["cus"] as CartVM;
            if (cus == null) return RedirectToAction("Index", "Home");
            ViewBag.countCart = cus.count;
            ViewBag.totalCart = cus.amount;
            ViewData["cart"] = cus._cart;
            //end load

            return View();
        }


        public JsonResult AddTocart()
        {
            String id = Request.Params["id"];

            String qty = Request.Params["qty"];

            if (id==null|| Session["cus"] == null) return Json(null, JsonRequestBehavior.AllowGet);

            var cus = Session["cus"] as CartVM;


            cus.addTocart(id,qty);

            Session["cus"] = cus;
            var pro = cus._cart;
            int cot = cus.count;
            var data = new { count = cot, total = cus.amount,product = pro };

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        // GET: Shop/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Shop/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Shop/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Shop/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Shop/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Shop/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Shop/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
