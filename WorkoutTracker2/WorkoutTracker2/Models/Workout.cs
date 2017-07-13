using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorkoutTracker2.Models
{
    public class Workout
    {
        public Workout() { WorkoutItems = new List<WorkoutItem>(); Id = Guid.NewGuid(); }

        //private DateTime workoutDate { get; set; }
        public string Name { get; set; }
        public Guid Id { get; set; }
        public Location Location { get; set; }
        public DateTime WorkoutDate { get; set; }
        public int WorkoutLength { get; set; }
        public List<WorkoutItem> WorkoutItems { get; set; }
        public int UserId { get; set; }

    }
}