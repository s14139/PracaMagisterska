using System;

namespace WorkoutTracker.Models
{
    public class ExcersiseSet
    {
        public int ExcerciseSetId { get; set; }
        public int numberOfRepetitions { get; set; }
        public decimal equipmentWeight { get; set; }
        public int ExcerciseId { get; set; }

        public virtual Excercise excercise { get; set; }
    }
}