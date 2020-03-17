using Girft_shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Girft_shop.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin/Main
        public ActionResult Index()
        {

            String msg = Request.Params["message"];
            String test = Request.Params["test"];
            ViewBag.msg = msg;
            // test open mode
            if (test == "1")
            {
                Session["user"] = test;
                return RedirectToAction("Orders");
            }

            return View();
        }

        public ActionResult Login()
        {
            String user = Request.Params["username"];
            String pass = Request.Params["pass"];
            var table = new girftEntities().accounts;
            var userModel = table.Where(x => x.userID==user).FirstOrDefault();
            var check = table.Where(x => x.userID == user);

            if (userModel != null)
            {
                var password = userModel.password.Trim();
                using (MD5 md5Hash = MD5.Create())
                {
                    String md5Pass = GetMd5Hash(md5Hash, pass);

                    if (md5Pass==password)
                    {
                        Session["user"] = user;
                        return RedirectToAction("Orders");
                    }
                    else
                    {
                        return RedirectToAction("Index", new { message = "login fail" });
                    }
                }
            }

           return RedirectToAction("Index", new { message = "login fail" });

        }

        public ActionResult Orders()
        {
            if (Session["user"] == null) return RedirectToAction("Index");

            return View();


        }

        public ActionResult Products()
        {
            if (Session["user"] == null) return RedirectToAction("Index");

            return View();


        }

        public ActionResult ProductCate()
        {
            if (Session["user"] == null) return RedirectToAction("Index");

            return View();


        }

        // GET: Admin/Main/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

      
        // GET: Admin/Main/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Main/Create
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

        // GET: Admin/Main/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Main/Edit/5
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

        // GET: Admin/Main/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Main/Delete/5
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

        static string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

    }
}
