using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WorkoutTracker2.Models;
using WorkoutTracker2.DAL;
using System.Web.Mvc;

namespace WorkoutTracker2.ViewModels
{
    public class WorkoutViewModel
    {
        public WorkoutViewModel()
        {
            Locations = WorkoutContext.Locations.Select(x => new SelectListItem() { Text = x.Name, Value = x.Id.ToString() });
            WorkoutItems = new List<WorkoutItem> ();
        }
        public WorkoutViewModel(Workout workout)
        {
            this.WorkoutDate = workout.WorkoutDate.ToString("dd-MM-yyyy");
            this.WorkoutItems = workout.WorkoutItems ?? new List<WorkoutItem>();
            this.WorkoutLength = workout.WorkoutLength;
            this.Location = workout.Location;
            this.Id = workout.Id;
            this.UserId = workout.UserId;
            Locations = WorkoutContext.Locations.Select(x => new SelectListItem() { Text = x.Name, Value = x.Id.ToString() });
        }
        public Guid Id { get; set; }
        public Location Location { get; set; }
        public string WorkoutDate { get; set; }
        public List<WorkoutItem> WorkoutItems { get; set; }
        public int WorkoutLength { get; set; }
        public int UserId { get; private set; }

        public IEnumerable<SelectListItem> Locations { get; set; }
    }
}