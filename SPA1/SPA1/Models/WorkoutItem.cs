using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SPA1.Models
{
    public class WorkoutItem
    {
        public WorkoutItem() { ExerciseSets = new List<ExerciseSet> { }; Id = Guid.NewGuid(); }

        public Guid Id { get; set; }
        public Exercise Exercise { get; set; }
        public Equipment Equipment { get; set; }
        public int NumberOfSets { get { return ExerciseSets.Count(); } }
        public decimal TotalWeight { get { return ExerciseSets.Select(x => x.equipmentWeight* x.numberOfRepetitions).Sum(); } }

        public ExerciseSet ExerciseSet
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public List<ExerciseSet> ExerciseSets;
    }
}