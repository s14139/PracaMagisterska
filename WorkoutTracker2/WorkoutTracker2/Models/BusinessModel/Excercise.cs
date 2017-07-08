using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorkoutTracker.Models
{
    public class Excercise
    {
        public Excercise() { secondaryMuscleGroups = new List<MuscleGroup>(); }

        public Guid ExcerciseId;
        public string ExcerciseName;
        public ExcerciseType type;
        public MuscleGroup primaryMuscleGroup;
        public IEnumerable<MuscleGroup> secondaryMuscleGroups;
        public Difficulty excerciseDifficulty;
        public Equipment equipment;
    }
}