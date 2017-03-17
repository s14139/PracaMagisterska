using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WorkoutTracker.Models;

namespace WorkoutTracker.DAL
{
    public class WorkoutInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<WorkoutContext>
    {
        protected override void Seed(WorkoutContext context)
        {
            var Difficutly = new List<Difficulty>();
            var Equipments = new List<Equipment>();
            var Excercises = new List<Excercise>();
            var ExcerciseTypes = new List<ExcerciseType>();
            var Locations = new List<Location>();
            var MuscleGroups = new List<MuscleGroup>();

            var ExcerciseSets = new List<ExcersiseSet>();
            var Workouts = new List<Workout>();
        }
    }
}