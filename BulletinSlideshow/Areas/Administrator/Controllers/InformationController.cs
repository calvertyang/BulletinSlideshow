﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BulletinSlideshow.Models;

namespace BulletinSlideshow.Areas.Administrator.Controllers
{
    public class InformationController : Controller
    {
        private BulletinSlideshowContext db = new BulletinSlideshowContext();

        //
        // GET: /Administrator/Information/

        public ActionResult Index()
        {
            var information = db.Information.Include(i => i.Category);
            return View(information.ToList());
        }

        //
        // GET: /Administrator/Information/Details/5

        public ActionResult Details(int id = 0)
        {
            Information information = db.Information.Find(id);
            if (information == null)
            {
                return HttpNotFound();
            }
            return View(information);
        }

        //
        // GET: /Administrator/Information/Create

        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name");
            return View();
        }

        //
        // POST: /Administrator/Information/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Information information)
        {
            if (ModelState.IsValid)
            {
                db.Information.Add(information);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", information.CategoryId);
            return View(information);
        }

        //
        // GET: /Administrator/Information/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Information information = db.Information.Find(id);
            if (information == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", information.CategoryId);
            return View(information);
        }

        //
        // POST: /Administrator/Information/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Information information)
        {
            if (ModelState.IsValid)
            {
                db.Entry(information).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", information.CategoryId);
            return View(information);
        }

        //
        // GET: /Administrator/Information/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Information information = db.Information.Find(id);
            if (information == null)
            {
                return HttpNotFound();
            }
            return View(information);
        }

        //
        // POST: /Administrator/Information/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Information information = db.Information.Find(id);
            db.Information.Remove(information);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}