using System;

namespace SPA1.Models
{
    public class ExerciseSet
    {
        public ExerciseSet() { }

        public Guid Id { get; set; }
        public Exercise excercise { get; set; }
        public int numberOfRepetitions { get; set; }
        public decimal equipmentWeight { get; set; }

        public Exercise Exercise
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }
    }
}