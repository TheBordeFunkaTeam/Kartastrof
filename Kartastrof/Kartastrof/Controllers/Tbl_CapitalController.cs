using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Kartastrof.Models;

namespace Kartastrof.Views.Home
{
    public class Tbl_CapitalController : Controller
    {
        private Capital db = new Capital();

        // GET: Tbl_Capital
        public ActionResult Index()
        {
            return View(db.Tbl_Capital.ToList());
        }

        // GET: Tbl_Capital/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Capital tbl_Capital = db.Tbl_Capital.Find(id);
            if (tbl_Capital == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Capital);
        }

        // GET: Tbl_Capital/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tbl_Capital/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Ca_Id,Ca_Name,Ca_Longitude,Ca_Latitude")] Tbl_Capital tbl_Capital)
        {
            if (ModelState.IsValid)
            {
                db.Tbl_Capital.Add(tbl_Capital);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_Capital);
        }

        // GET: Tbl_Capital/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Capital tbl_Capital = db.Tbl_Capital.Find(id);
            if (tbl_Capital == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Capital);
        }

        // POST: Tbl_Capital/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Ca_Id,Ca_Name,Ca_Longitude,Ca_Latitude")] Tbl_Capital tbl_Capital)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Capital).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_Capital);
        }

        // GET: Tbl_Capital/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Capital tbl_Capital = db.Tbl_Capital.Find(id);
            if (tbl_Capital == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Capital);
        }

        // POST: Tbl_Capital/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tbl_Capital tbl_Capital = db.Tbl_Capital.Find(id);
            db.Tbl_Capital.Remove(tbl_Capital);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
