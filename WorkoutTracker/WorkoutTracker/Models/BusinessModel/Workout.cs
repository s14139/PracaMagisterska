using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorkoutTracker.Models
{
    public class Workout
    {
        Guid WorkoutId;
        Location location;
        DateTime workoutDate;
        TimeSpan workoutLength;
        IEnumerable<ExcersiseSet> sets;
        Guid UserId;
    }
}