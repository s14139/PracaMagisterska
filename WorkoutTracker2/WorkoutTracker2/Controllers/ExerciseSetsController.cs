using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WorkoutTracker2.Models;
using WorkoutTracker2.ViewModels;
using WorkoutTracker2.DAL;

namespace WorkoutTracker2.Controllers
{
    public class ExerciseSetsController : Controller
    {

        // GET: ExerciseSets
        public ActionResult Index()
        {
            return View(WorkoutContext.ExerciseSets.ToList());
        }

        // GET: ExerciseSets/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExerciseSet exerciseSet = WorkoutContext.ExerciseSets.FirstOrDefault(x => x.Id == id);
            if (exerciseSet == null)
            {
                return HttpNotFound();
            }
            return View(exerciseSet);
        }

        // GET: ExerciseSets/Create
        public ActionResult Create(Guid WorkoutId, Guid WorkoutItemId)
        {
            return View(new ExerciseSetViewModel(WorkoutId, WorkoutItemId));
        }

        // POST: ExerciseSets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WorkoutId,WorkoutItemId,NumberOfRepetitions,Weight")] ExerciseSetViewModel viewModel)
        {
            if (ModelState.IsValid)
            {

                WorkoutContext.Workouts.Single(x =>x.Id == viewModel.WorkoutId).WorkoutItems.Single(x => x.Id == viewModel.WorkoutItemId).ExerciseSets.Add(new ExerciseSet() { Id = Guid.NewGuid(), equipmentWeight = viewModel.Weight, numberOfRepetitions = viewModel.NumberOfRepetitions });
            }

            return RedirectToAction("Details", "Workouts", new { id = viewModel.WorkoutId });
        }

        // GET: ExerciseSets/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExerciseSet exerciseSet = WorkoutContext.ExerciseSets.FirstOrDefault(x => x.Id == id);
            if (exerciseSet == null)
            {
                return HttpNotFound();
            }
            return View(exerciseSet);
        }

        // POST: ExerciseSets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,numberOfRepetitions,equipmentWeight")] ExerciseSet exerciseSet)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            return View(exerciseSet);
        }

        // GET: ExerciseSets/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExerciseSet exerciseSet = WorkoutContext.ExerciseSets.FirstOrDefault(x => x.Id == id);
            if (exerciseSet == null)
            {
                return HttpNotFound();
            }
            return View(exerciseSet);
        }

        // POST: ExerciseSets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            ExerciseSet exerciseSet = WorkoutContext.ExerciseSets.FirstOrDefault(x => x.Id == id);
            WorkoutContext.ExerciseSets.Remove(exerciseSet);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
