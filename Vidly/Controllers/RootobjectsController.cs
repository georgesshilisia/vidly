using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class RootobjectsController : Controller
    {
        private EvyEventDbContext db = new EvyEventDbContext();

        // GET: Rootobjects
        public async Task<ActionResult> Index()
        {
            return View(await db.Eventbrite.ToListAsync());
        }

        // GET: Rootobjects/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rootobject rootobject = await db.Eventbrite.FindAsync(id);
            if (rootobject == null)
            {
                return HttpNotFound();
            }
            return View(rootobject);
        }

        // GET: Rootobjects/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Rootobjects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id")] Rootobject rootobject)
        {
            if (ModelState.IsValid)
            {
                db.Eventbrite.Add(rootobject);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(rootobject);
        }

        // GET: Rootobjects/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rootobject rootobject = await db.Eventbrite.FindAsync(id);
            if (rootobject == null)
            {
                return HttpNotFound();
            }
            return View(rootobject);
        }

        // POST: Rootobjects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id")] Rootobject rootobject)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rootobject).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(rootobject);
        }

        // GET: Rootobjects/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rootobject rootobject = await db.Eventbrite.FindAsync(id);
            if (rootobject == null)
            {
                return HttpNotFound();
            }
            return View(rootobject);
        }

        // POST: Rootobjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Rootobject rootobject = await db.Eventbrite.FindAsync(id);
            db.Eventbrite.Remove(rootobject);
            await db.SaveChangesAsync();
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
