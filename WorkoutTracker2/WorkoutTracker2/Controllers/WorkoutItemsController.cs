using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WorkoutTracker2.DAL;
using WorkoutTracker2.Models;
using WorkoutTracker2.ViewModels;

namespace WorkoutTracker2.Controllers
{
    public class WorkoutItemsController : Controller
    {
        // GET: WorkoutItems
        public ActionResult Index()
        {
            return View(WorkoutContext.WorkoutItems.ToList());
        }

        // GET: WorkoutItems/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkoutItem workoutItem = WorkoutContext.WorkoutItems.FirstOrDefault(x => x.Id == id);
            if (workoutItem == null)
            {
                return HttpNotFound();
            }
            return View(workoutItem);
        }

        // GET: WorkoutItems/Create
        public ActionResult Create(Guid WorkoutId)
        {
            return View(new WorkoutItemViewModel() { WorkoutId = WorkoutId });
        }


        // POST: WorkoutItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Equipment,Exercise,WorkoutId")] WorkoutItemViewModel workoutItemViewModel)
        {
            if (ModelState.IsValid)
            {
                var workoutItem = new WorkoutItem()
                {
                    Id = Guid.NewGuid(),
                    Equipment = WorkoutContext.Equipments.SingleOrDefault(x => x.Id == workoutItemViewModel.Equipment),
                    Exercise = WorkoutContext.Exercises.SingleOrDefault(x => x.Id == workoutItemViewModel.Exercise), 
                    ExerciseSets = new List<ExerciseSet> { }

                };
                WorkoutContext.Workouts.Single(x => x.Id == workoutItemViewModel.WorkoutId).WorkoutItems.Add(workoutItem);
            }
            return RedirectToAction("Details", "Workouts", new { id =  workoutItemViewModel.WorkoutId });

        }

        // GET: WorkoutItems/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkoutItem workoutItem = WorkoutContext.WorkoutItems.FirstOrDefault(x=> x.Id == id);
            if (workoutItem == null)
            {
                return HttpNotFound();
            }
            return View(workoutItem);
        }

        // POST: WorkoutItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id")] WorkoutItem workoutItem)
        {
            if (ModelState.IsValid)
            {
                WorkoutContext.WorkoutItems.Single(x => x.Id == workoutItem.Id);
                return RedirectToAction("Index");
            }
            return View(workoutItem);
        }

        // GET: WorkoutItems/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkoutItem workoutItem = WorkoutContext.WorkoutItems.FirstOrDefault(x => x.Id == id);
            if (workoutItem == null)
            {
                return HttpNotFound();
            }
            return View(workoutItem);
        }

        // POST: WorkoutItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            WorkoutItem workoutItem = WorkoutContext.WorkoutItems.FirstOrDefault(x=>x.Id == id);
            WorkoutContext.WorkoutItems.Remove(workoutItem);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
