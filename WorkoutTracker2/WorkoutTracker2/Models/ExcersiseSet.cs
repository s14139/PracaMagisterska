using System;

namespace WorkoutTracker2.Models
{
    public class ExerciseSet
    {
        public ExerciseSet() { }

        public Guid Id { get; set; }
        public int numberOfRepetitions { get; set; }
        public decimal equipmentWeight { get; set; }       
    }
}