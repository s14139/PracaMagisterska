using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorkoutTracker.Models
{
    public class Excercise
    {
        Guid ExcerciseId;
        string ExcerciseName;
        ExcerciseType type;
        MuscleGroup muscleGroup;
        Difficulty excerciseDifficulty;
        Equipment equipment;
    }
}