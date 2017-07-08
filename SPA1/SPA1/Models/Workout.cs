using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SPA1.Models
{
    public class Workout
    {
        public Workout() { WorkoutItems = new List<WorkoutItem>(); Id = Guid.NewGuid(); }

        public Guid Id { get; set; }
        public Location location { get; set; }
        public DateTime workoutDate { get; set; }
        public int workoutLength { get; set; }
        public List<WorkoutItem> WorkoutItems { get; set; }
        public int UserId { get; set; }

        public WorkoutItem WorkoutItem
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public Location Location
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