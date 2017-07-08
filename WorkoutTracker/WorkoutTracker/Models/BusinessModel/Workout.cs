using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorkoutTracker.Models
{
    public class Workout
    {
        public Workout() { sets = new List<ExcersiseSet>(); }

        public int WorkoutId { get; set; }
        public DateTime workoutDate { get; set; }
        public TimeSpan workoutLength { get; set; }
        //public int UserId { get; set; }
        public int LocationId { get; set; }

        public virtual Location location { get; set; }
        public virtual ICollection<ExcersiseSet> sets { get; set; }
    }
}