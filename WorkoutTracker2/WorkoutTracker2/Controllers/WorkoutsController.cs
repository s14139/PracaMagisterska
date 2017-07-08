using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WorkoutTracker2.Models;
using WorkoutTracker2.DAL;
using WorkoutTracker2.ViewModels;

namespace WorkoutTracker2.Controllers
{
    public class WorkoutsController : Controller
    {
        public JsonResult FillIndexKO()
        {
            return Json(WorkoutContext.Workouts.ToList(), JsonRequestBehavior.AllowGet);
        }
        // GET: Workouts
        public ActionResult Index()
        {
            return View(WorkoutContext.Workouts.ToList());
        }

        public ActionResult IndexKO()
        {
            return View(WorkoutContext.Workouts.ToList());
        }

        // GET: Workouts/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Workout workout = WorkoutContext.Workouts.Single(x => x.Id == id);
            if (workout == null)
            {
                return HttpNotFound();
            }
            return View(workout);
        }

        public ActionResult AddWorkoutItem(Guid id)
        {
            return RedirectToAction("Create", "WorkoutItems", new { WorkoutId = id });
        }

        public ActionResult AddExerciseSet(Guid WorkoutId, Guid WorkoutItemId)
        {
            return RedirectToAction("Create", "ExerciseSets", new { WorkoutId = WorkoutId, WorkoutItemId = WorkoutItemId });
        }

        public ActionResult EditWorkoutItem(Guid id)
        {
            return RedirectToAction("Edit", "WorkoutItems", new { id = id });
        }

        // GET: Workouts/Create
        public ActionResult Create()
        {
            return View(new WorkoutViewModel());
        }

        // POST: Workouts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,WorkoutDate,WorkoutLength")] WorkoutViewModel workoutViewModel)
        {
            var workout = new Workout();
            if (ModelState.IsValid)
            {
                                workout.Id = Guid.NewGuid();
                workout.UserId = 1;
                workout.Location = workoutViewModel.Location;
                workout.WorkoutDate = DateTime.Parse(workoutViewModel.WorkoutDate);
                workout.WorkoutLength = workoutViewModel.WorkoutLength;
                workout.WorkoutItems = workoutViewModel.WorkoutItems;
                WorkoutContext.Workouts.Add(workout);
                return RedirectToAction("Details", new { id = workout.Id });
                // return RedirectToAction("Index");
            }

            return View(workout);
        }

        // GET: Workouts/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Workout workout = WorkoutContext.Workouts.Single(x => x.Id == id);
            if (workout == null)
            {
                return HttpNotFound();
            }
            return View(workout);
        }

        // POST: Workouts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,workoutDate,workoutLength,UserId")] Workout workout)
        {
            if (ModelState.IsValid)
            {
                var wo = WorkoutContext.Workouts.Single(x => x.Id == workout.Id);
                wo = workout;
                return RedirectToAction("Index");
            }
            return View(workout);
        }

        // GET: Workouts/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Workout workout = WorkoutContext.Workouts.Single(x => x.Id == id);
            if (workout == null)
            {
                return HttpNotFound();
            }
            return View(workout);
        }

        // POST: Workouts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Workout workout = WorkoutContext.Workouts.Single(x => x.Id == id);
            WorkoutContext.Workouts.Remove(workout);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
        }
    }
}
