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
    public class MeetupModelsController : Controller
    {
        private EvyEventDbContext db = new EvyEventDbContext();

        // GET: MeetupModels
        public async Task<ActionResult> Index()
        {
            return View(await db.Meetup.ToListAsync());
        }

        // GET: MeetupModels/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MeetupModel meetupModel = await db.Meetup.FindAsync(id);
            if (meetupModel == null)
            {
                return HttpNotFound();
            }
            return View(meetupModel);
        }

        // GET: MeetupModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MeetupModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id")] MeetupModel meetupModel)
        {
            if (ModelState.IsValid)
            {
                db.Meetup.Add(meetupModel);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(meetupModel);
        }

        // GET: MeetupModels/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MeetupModel meetupModel = await db.Meetup.FindAsync(id);
            if (meetupModel == null)
            {
                return HttpNotFound();
            }
            return View(meetupModel);
        }

        // POST: MeetupModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id")] MeetupModel meetupModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(meetupModel).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(meetupModel);
        }

        // GET: MeetupModels/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MeetupModel meetupModel = await db.Meetup.FindAsync(id);
            if (meetupModel == null)
            {
                return HttpNotFound();
            }
            return View(meetupModel);
        }

        // POST: MeetupModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            MeetupModel meetupModel = await db.Meetup.FindAsync(id);
            db.Meetup.Remove(meetupModel);
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
