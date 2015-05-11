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
    public class PagesController : Controller
    {
        private PageCMS2Context db = new PageCMS2Context();

        // GET: Pages
        public ActionResult Index(string searchCategory)
        {
            var pages = db.Pages.Include(p => p.Category);

            var Categories = from c in db.Categories
                             select c;

            List<string> pageCategoryStrings = new List<string>();

            foreach (Category category in Categories)
            {
                pageCategoryStrings.Add(category.Title);
            }

            ViewBag.searchCategory = new SelectList(pageCategoryStrings);

            if (!String.IsNullOrEmpty(searchCategory))
            {
                pages = pages.Where(s => s.Category.Title.Contains(searchCategory));
            }

            return View(pages.ToList());
        }

        // GET: Pages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Page page = db.Pages.Find(id);
            if (page == null)
            {
                return HttpNotFound();
            }
            return View(page);
        }

        // GET: Pages/Create
        public ActionResult Create()
        {
            ICollection<Category> avaliable_categories = db.Categories.ToList();
            ViewBag.avaliable_categories = avaliable_categories;

            return View();
        }

        // POST: Pages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Title,Description,Category")] PageCategoryViewModel pageWithCategory)
        {
            if (ModelState.IsValid)
            {
                //See if the category exist
                Category category = db.Categories.FirstOrDefault(c => c.Title == pageWithCategory.Category);
                // If on if the category exust
                if (category != null)
                {
                    //Category exist. 
                    if (category.Pages.Any(c => c.Title == pageWithCategory.Title))
                    {
                        ModelState.AddModelError("Title", "The page title needs to be unque in reguard to its category.");
                        //add error and return to get create view
                        //Error Page title need to be unique with reguard to its category
                        ICollection<Category> avaliable_categories = db.Categories.ToList();
                        ViewBag.avaliable_categories = avaliable_categories;
                        return View(pageWithCategory);
                    }

                    Page page = new Page { Title = pageWithCategory.Title, Description = pageWithCategory.Description, Category = category };
                    db.Pages.Add(page);
                }
                else
                {
                    category = new Category { Title = pageWithCategory.Category };
                    db.Categories.Add(category);
                    Page page = new Page { Title = pageWithCategory.Title, Description = pageWithCategory.Description, Category = category };
                    db.Pages.Add(page);
                }

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(pageWithCategory);
            }

            
        }

        // GET: Pages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Page page = db.Pages.Find(id);
            ViewBag.new_section = new Section { Page = page };
            if (page == null)
            {
                return HttpNotFound();
            }
            return View(page);
        }

        // POST: Pages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,Description")] Page page)
        {
            if (ModelState.IsValid)
            {
                db.Entry(page).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(page);
        }

        // GET: Pages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Page page = db.Pages.Find(id);
            if (page == null)
            {
                return HttpNotFound();
            }
            return View(page);
        }

        // POST: Pages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Page page = db.Pages.Find(id);
            db.Pages.Remove(page);
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
