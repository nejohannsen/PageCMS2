using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PageCMS2.Models;

namespace PageCMS2.Controllers
{
    public class SectionsController : Controller
    {
        private PageCMS2Context db = new PageCMS2Context();

        // GET: Sections
        public ActionResult Index()
        {
            return View(db.Sections.ToList());
        }

        // GET: Sections/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Section section = db.Sections.Find(id);
            if (section == null)
            {
                return HttpNotFound();
            }
            return View(section);
        }

        // GET: Sections/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sections/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Page")] SectionForPage sectionWithPage)
        {

            if (ModelState.IsValid)
            {
                Page page = db.Pages.Find(Convert.ToInt32(sectionWithPage.Page));
                Section section = new Section { Page = page, Position = page.Sections.Count + 1 };
                db.Sections.Add(section);
                db.SaveChanges();
                return RedirectToAction("Edit", "Pages", new { id = page.ID });
            }

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        // GET: Sections/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Section section = db.Sections.Find(id);
            if (section == null)
            {
                return HttpNotFound();
            }
            return View(section);
        }

        // POST: Sections/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Position,Value")] Section section)
        {
            if (ModelState.IsValid)
            {
                db.Entry(section).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(section);
        }

        // GET: Sections/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Section section = db.Sections.Find(id);
            if (section == null)
            {
                return HttpNotFound();
            }
            return View(section);
        }

        // POST: Sections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Section section = db.Sections.Find(id);
            Page page = section.Page;
            db.Sections.Remove(section);
            db.SaveChanges();
            return RedirectToAction("Edit", "Pages", new { id = page.ID });
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
