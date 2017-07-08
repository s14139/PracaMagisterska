using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WorkoutTracker2.Models;
using WorkoutTracker2.DAL;
using System.Web.Mvc;

namespace WorkoutTracker2.ViewModels
{
    public class ExerciseSetViewModel
    {
        public ExerciseSetViewModel()
        {
        }

        public ExerciseSetViewModel(Guid workoutId, Guid workoutItemId)
        {
            WorkoutId = workoutId;
            WorkoutItemId = workoutItemId;
        }

        public Guid WorkoutId { get; set; }
        public Guid WorkoutItemId { get; set; }

        public int NumberOfRepetitions { get; set; }
        public decimal Weight { get; set; }
    }
}