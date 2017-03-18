using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorkoutTracker.Models
{
    public class Workout
    {
        public Guid WorkoutId;
        public Location location;
        public DateTime workoutDate;
        public TimeSpan workoutLength;
        public IEnumerable<ExcersiseSet> sets;
        public Guid UserId;
    }
}