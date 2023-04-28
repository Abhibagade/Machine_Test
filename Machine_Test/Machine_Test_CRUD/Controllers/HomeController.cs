using Machine_Test_CRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySql.Data.MySqlClient;

namespace Machine_Test_CRUD.Controllers
{
    public class HomeController : Controller
    {

        ProductContext db = new ProductContext();
        public ActionResult Index()
        {
            var products = db.products.ToList();

            return View(products);
        }

        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Create(ProductList p)
        {
            if (ModelState.IsValid == true)
            {
                db.products.Add(p);
                int a = db.SaveChanges();
                if (a > 0)
                {
                    TempData["create"] = "Product Inserted Successfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["create"] = "Product is not Inserted";
                }
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            var data = db.products.Where(model => model.ProductId == id).FirstOrDefault();

            return View(data);
        }

        [HttpPost]
        public ActionResult Edit(ProductList p)
        {
            db.Entry(p).State = System.Data.Entity.EntityState.Modified;
            int a = db.SaveChanges();
            if (a > 0)
            {
                TempData["update"] = "Product Updated Successfully";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["update"] = "Product Not Updated";
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            var data = db.products.Where(model => model.ProductId == id).FirstOrDefault();

            return View(data);
        }

        [HttpPost]
        public ActionResult Delete(ProductList p)
        {
            db.Entry(p).State = System.Data.Entity.EntityState.Deleted;
            int a = db.SaveChanges();
            if (a > 0)
            {
                TempData["delete"] = "Product Deleted Successfully";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["delete"] = "Product is not Deleted";
            }

            return View();
        }


        public ActionResult Details(int id)
        {
            var row = db.products.Where(model => model.ProductId == id).FirstOrDefault();

            return View(row);
        }
    }
}
   
