using System;

namespace WorkoutTracker.Models
{
    public class ExcersiseSet
    {
        public Guid ExcerciseSetId;
        public Excercise excercise;
        public int numberOfRepetitions;
        public decimal equipmentWeight;
    }
}