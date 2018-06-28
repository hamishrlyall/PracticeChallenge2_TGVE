using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TGVE.Models;
using TGVE.ViewModels;

namespace TGVE.Controllers
{
    public class TourEventsController : Controller
    {
        private PracticeChallenge2_TGVEEntities2 db = new PracticeChallenge2_TGVEEntities2();

        // GET: TourEvents
        public ActionResult Index(int? eventID, int? bookingID)
        {
            /*var tourEvents = db.TourEvents.Include(t => t.Tour);
            return View(tourEvents.ToList());*/
            var viewModel = new TourEventsIndexData();
            viewModel.TourEvents = db.TourEvents
                .Include(e => e.Bookings.Select(b => b.Client))
                .OrderBy(e => e.EventDate);

            if (eventID != null)
            {
                ViewBag.EventID = eventID.Value;
                viewModel.Bookings = viewModel.TourEvents.Where(
                    b => b.EventID == eventID.Value).Single().Bookings;

            }
            if (bookingID != null)
            {
                ViewBag.BookingID = bookingID.Value;
                viewModel.Bookings = viewModel.TourEvents.Where(
                    x => x.EventID == eventID).Single().Bookings;
            }
            return View(viewModel);
        }

            // GET: TourEvents/Details/5
            public ActionResult Details(DateTime id)
            {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TourEvent tourEvent = db.TourEvents.Find(id);
            if (tourEvent == null)
            {
                return HttpNotFound();
            }
            return View(tourEvent);
            }

        // GET: TourEvents/Create
        public ActionResult Create()
        {
            ViewBag.TourName = new SelectList(db.Tours, "TourName", "Description");
            return View();
        }

        // POST: TourEvents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EventDate,Fee,TourName")] TourEvent tourEvent)
        {
            if (ModelState.IsValid)
            {
                db.TourEvents.Add(tourEvent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TourName = new SelectList(db.Tours, "TourName", "Description", tourEvent.TourName);
            return View(tourEvent);
        }

        // GET: TourEvents/Edit/5
        public ActionResult Edit(DateTime id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TourEvent tourEvent = db.TourEvents.Find(id);
            if (tourEvent == null)
            {
                return HttpNotFound();
            }
            ViewBag.TourName = new SelectList(db.Tours, "TourName", "Description", tourEvent.TourName);
            return View(tourEvent);
        }

        // POST: TourEvents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EventDate,Fee,TourName")] TourEvent tourEvent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tourEvent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TourName = new SelectList(db.Tours, "TourName", "Description", tourEvent.TourName);
            return View(tourEvent);
        }

        // GET: TourEvents/Delete/5
        public ActionResult Delete(DateTime id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TourEvent tourEvent = db.TourEvents.Find(id);
            if (tourEvent == null)
            {
                return HttpNotFound();
            }
            return View(tourEvent);
        }

        // POST: TourEvents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(DateTime id)
        {
            TourEvent tourEvent = db.TourEvents.Find(id);
            db.TourEvents.Remove(tourEvent);
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
