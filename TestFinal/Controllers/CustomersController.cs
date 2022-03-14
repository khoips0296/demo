using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TestFinal.Models;

namespace TestFinal.Controllers
{
    public class CustomersController : Controller
    {
        private CustomerDBContext db = new CustomerDBContext();

        // GET: Customers
        public ActionResult Index()
        {
            ViewBag.TypeId = new SelectList(db.CustomerTypes, "TypeId", "TypeName");
            var customers = (from c in db.Customers select c);
            return View(customers.ToList());
        }

        //filter
        [HttpPost]
        public ActionResult Index(int TypeId, string name)
        {
            var customers = (from c in db.Customers select c);
            if (name == "")
            {
                 customers = (from c in db.Customers where c.TypeId == TypeId select c);
            }
            else
            {
                 customers = (from c in db.Customers where c.TypeId == TypeId && c.FullName== name select c);
            }

            ViewBag.TypeId = new SelectList(db.CustomerTypes, "TypeId", "TypeName");
            ViewBag.CustomerCount = customers.Count();
            
            return View(customers.ToList());
        }

        public ActionResult DisplayAll()
        {
            //ViewBag.TypeId = new SelectList(db.CustomerTypes, "TypeId", "TypeName");
            //var customers = (from c in db.Customers select c);
            return Redirect("Index");
        }



        


        public ActionResult Delete(int id)
        {
           
            Customer customer = db.Customers.Find(id);
            return View(customer);
        }

        // POST: 
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
            db.SaveChanges();
            TempData["msg"] = "xoa thanh cong";

            return RedirectToAction("Index");
        }



        
    }
}
