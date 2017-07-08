using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorkoutTracker2.Models
{
    public class Exercise
    {
        public Exercise() { }

        public int Id { get; set; }
        public string ExcerciseName { get; set; }
        public ExerciseType Type { get; set; }
        public MuscleGroup MuscleGroup { get; set; }
        public Difficulty ExcerciseDifficulty { get; set; }
        public Equipment Equipment { get; set; }


        public override string ToString()
        {
            return $"{ExcerciseName} - {Equipment?.Name}";
        }
    }
}