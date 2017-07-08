using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SPA1.Models;
using SPA1.DAL;
using System.Web.Mvc;

namespace SPA1.ViewModels
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