using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using WorkoutTracker.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace WorkoutTracker.DAL
{
    public class WorkoutContext : DbContext
    {
        WorkoutContext() : base("DefaultConnection") { }

        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<Excercise> Excercises { get; set; }
        public DbSet<ExcerciseType> ExcerciseTypes { get; set; }
        public DbSet<ExcersiseSet> ExcersiseSets { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<MuscleGroup> MuscleGroups { get; set; }
        public DbSet<Workout> Workouts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}