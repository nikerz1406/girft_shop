﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Girft_shop.Controllers
{
    public class FaqController : Controller
    {
        // GET: Faq
        public ActionResult Index()
        {
            //load cart
            var cus = Session["cus"] as Girft_shop.ViewModel.CartVM;
            ViewBag.countCart = cus.count;
            ViewBag.totalCart = cus.amount;
            ViewData["cart"] = cus._cart;
            //end load
            return View();
        }

        // GET: Faq/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Faq/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Faq/Create
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

        // GET: Faq/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Faq/Edit/5
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

        // GET: Faq/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Faq/Delete/5
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
