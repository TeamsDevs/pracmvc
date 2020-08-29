using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using pracmvc.Models;

namespace pracmvc.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            //to save akumas
            using (DatabaseModel db = new DatabaseModel())
            {
                return View(db.tbCustomers.ToList());
               
            }
              
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            using (DatabaseModel db = new DatabaseModel())
            {
                return View(db.tbCustomers.Where(x=>x.ID==id).FirstOrDefault());

            }
               
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(tbCustomer customer)
        {
            try
            {
                // TODO: Add insert logic here
                using (DatabaseModel db = new DatabaseModel())
                {
                    db.tbCustomers.Add(customer);
                    db.SaveChanges();
                }
             
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
          
                return View();
            }
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            using (DatabaseModel db = new DatabaseModel())
            {

                return View(db.tbCustomers.Where(x => x.ID == id).FirstOrDefault()); 
            }
                
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, tbCustomer customer)
        {
            try
            {
                // TODO: Add update logic here
                using (DatabaseModel db = new DatabaseModel())

                {
                    db.Entry(customer).State = EntityState.Modified;
                    db.SaveChanges();

                }
                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            using (DatabaseModel db = new DatabaseModel())
            {
                return View(db.tbCustomers.Where(x=>x.ID==id).FirstOrDefault());
            }
               
        }

        // POST: Customer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, tbCustomer customer)
        {
            try
            {
                // TODO: Add delete logic here
                using (DatabaseModel db = new DatabaseModel())
                {
                    customer = db.tbCustomers.Where(x=>x.ID==id).FirstOrDefault();
                    db.tbCustomers.Remove(customer);
                    db.SaveChanges();

                }
                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
