using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorkoutTracker.Models
{
    public class Excercise
    {
        public int ExcerciseId { get; set; }
        public string ExcerciseName { get; set; }
        public int ExcerciseTypeId { get; set; }
        public int MuscleGroupId { get; set; }
        public int Difficulty { get; set; }
        public int EquipmentId { get; set; }

        public virtual ExcerciseType type { get; set; }
        public virtual MuscleGroup primaryMuscleGroup { get; set; }
        public virtual Difficulty excerciseDifficulty { get; set; }
        public virtual Equipment equipment { get; set; }
    }
}