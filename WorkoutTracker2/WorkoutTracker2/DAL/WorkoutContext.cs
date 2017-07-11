using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using WorkoutTracker2.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace WorkoutTracker2.DAL
{
    public class WorkoutContext
    {
        static WorkoutContext() {
            Difficulties = new List<Difficulty>
            {
                new Difficulty() { Id = 1, Name = "easy" },
                new Difficulty() { Id = 2, Name = "medium" },
                new Difficulty() { Id = 3, Name = "hard" }
            };

            Equipments = new List<Equipment>
            {
                new Equipment() { Id = 1, Name = "Flat bench" },
                new Equipment() { Id = 2, Name = "Chinup bar" },
                new Equipment() { Id = 3, Name = "Dumbbells" },
                new Equipment() { Id = 4, Name = "Treadmill" }
            };

            ExerciseTypes = new List<ExerciseType>
            {
                new ExerciseType() { Id = 1, Name = "Cardiovascular" },
                new ExerciseType() { Id = 2, Name = "Strength" },
                new ExerciseType() { Id = 3, Name = "Flexibility" },
                new ExerciseType() { Id = 4, Name = "Balance" },
            };

            Locations = new List<Location>
            {
                new Location() { Id = 1, Name = "Total Fitness Ursynow" },
                new Location() { Id = 2, Name = "Bodyshape" }
            };

            MuscleGroups = new List<MuscleGroup>
            {
                new MuscleGroup() { Id = 1, Name = "Chest" },
                new MuscleGroup() { Id = 2, Name = "Biceps" },
                new MuscleGroup() { Id = 3, Name = "Quadriceps" },
                new MuscleGroup() { Id = 4, Name = "Lower back" },
                new MuscleGroup() { Id = 5, Name = "Triceps" },
                new MuscleGroup() { Id = 6, Name = "Hamstrings" },
                new MuscleGroup() { Id = 7, Name = "Lats" },
                new MuscleGroup() { Id = 8, Name = "Abs" },
                new MuscleGroup() { Id = 9, Name = "Glutes" },
                new MuscleGroup() { Id = 10, Name = "Deltoids" },
                new MuscleGroup() { Id = 11, Name = "Forearm" },
            };

            Exercises = new List<Exercise>
            {
                new Exercise() {
                    Id = 1,
                    Equipment = Equipments.Single(x => x.Name == "Flat bench"),
                    ExcerciseDifficulty = Difficulties.Single(x => x.Id == 2),
                    MuscleGroup = MuscleGroups.Single( x => x.Id == 1),
                    Type = ExerciseTypes.Single(x => x.Id == 2),
                    ExcerciseName = "Bench press"
                },

                new Exercise() {
                    Id = 2,
                    Equipment = Equipments.Single(x => x.Name == "Chinup bar"),
                    ExcerciseDifficulty = Difficulties.Single(x => x.Id == 2),
                    MuscleGroup = MuscleGroups.Single( x => x.Id == 7),
                    Type = ExerciseTypes.Single(x => x.Id == 2),
                    ExcerciseName = "Chinups"
                },

                new Exercise() {
                    Id = 3,
                    Equipment = Equipments.Single(x => x.Name == "Dumbbells"),
                    ExcerciseDifficulty = Difficulties.Single(x => x.Id == 2),
                    MuscleGroup = MuscleGroups.Single( x => x.Id == 2),
                    Type = ExerciseTypes.Single(x => x.Id == 2),
                    ExcerciseName = "Bicep curl"
                },
                new Exercise() {
                    Id = 4,
                    Equipment = Equipments.Single(x => x.Name == "Treadmill"),
                    ExcerciseDifficulty = Difficulties.Single(x => x.Id == 2),
                    MuscleGroup = MuscleGroups.Single( x => x.Id == 3),
                    Type = ExerciseTypes.Single(x => x.Id == 1),
                    ExcerciseName = "Running"
                },
            };
            ExerciseSets = new List<ExerciseSet>();
            Workouts = new List<Workout>() { new Workout() { UserId = 1, WorkoutDate = DateTime.Now, Location = Locations.First(), WorkoutLength = 2,
                WorkoutItems = new List<WorkoutItem> {
                    new WorkoutItem() {
                        Equipment = Equipments.First(), Exercise = Exercises.First(), ExerciseSets = new List<ExerciseSet> {
                            new ExerciseSet() {  equipmentWeight = 20, numberOfRepetitions = 10}
                        }
                    } } } };
        }


        public static List<Difficulty> Difficulties { get; set; }
        public static List<Equipment> Equipments { get; set; }
        public static List<Exercise> Exercises { get; set; }
        public static List<ExerciseType> ExerciseTypes { get; set; }
        public static List<ExerciseSet> ExerciseSets { get; set; }
        public static List<Location> Locations { get; set; }
        public static List<MuscleGroup> MuscleGroups { get; set; }
        public static List<Workout> Workouts { get; set; }
        public static List<WorkoutItem> WorkoutItems { get; set; }

        public static PickListDTO PicklistDTO { get { return new PickListDTO() { Equipments = Equipments, Exercises = Exercises, Locations = Locations }; } }
    }

    public class PickListDTO
    {
        public List<Exercise> Exercises;
        public List<Equipment> Equipments;
        public List<Location> Locations;
    }
}