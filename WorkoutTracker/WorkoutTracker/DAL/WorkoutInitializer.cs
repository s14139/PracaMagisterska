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
            var Difficutly = new List<Difficulty>
            {
                new Difficulty() { Name = "easy" },
                new Difficulty() { Name = "medium" },
                new Difficulty() { Name = "hard" }
            };

            var Equipments = new List<Equipment>
            {
                new Equipment() { Name = "Flat bench" },
                new Equipment() { Name = "Chinup bar" },
                new Equipment() { Name = "Dumbbells" }
            };

            var ExcerciseTypes = new List<ExcerciseType>
            {
                new ExcerciseType() { Name = "Cardiovascular" },
                new ExcerciseType() { Name = "Strength" },
                new ExcerciseType() { Name = "Flexibility" },
                new ExcerciseType() { Name = "Balance" },
            };

            var Locations = new List<Location>
            {
                new Location() { Name = "Total Fitness Ursynów" },
                new Location() { Name = "Bodyshape" }
            };

            var MuscleGroups = new List<MuscleGroup>
            {
                new MuscleGroup() { Name = "Chest" },
                new MuscleGroup() { Name = "Biceps" },
                new MuscleGroup() { Name = "Quadriceps" },
                new MuscleGroup() { Name = "Lower back" },
                new MuscleGroup() { Name = "Triceps" },
                new MuscleGroup() { Name = "Hamstrings" },
                new MuscleGroup() { Name = "Lats" },
                new MuscleGroup() { Name = "Abs" },
                new MuscleGroup() { Name = "Glutes" },
                new MuscleGroup() { Name = "Deltoids" },
                new MuscleGroup() { Name = "Forearm" },
            };

            var Excercises = new List<Excercise>();
            var ExcerciseSets = new List<ExcersiseSet>();
            var Workouts = new List<Workout>();
        }
    }
}