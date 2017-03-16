using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WorkoutTracker.Models
{
    public class WorkoutContext : DbContext
    {
        WorkoutContext() : base("WorkoutContext") { }

        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<Excercise> Excercises { get; set; }
        public DbSet<ExcerciseType> ExcerciseTypes { get; set; }
        public DbSet<ExcersiseSet> ExcersiseSets { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<MuscleGroup> MuscleGroups { get; set; }
        public DbSet<Workout> Workouts { get; set; }

    }
}