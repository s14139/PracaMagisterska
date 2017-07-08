using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SPA1.Models;
using SPA1.DAL;
using System.Web.Mvc;


namespace SPA1.ViewModels
{
    public class WorkoutItemViewModel
    {
        public WorkoutItemViewModel()
        {
            Equipments = WorkoutContext.Equipments.Select(x => new SelectListItem() { Text = x.Name, Value = x.Id.ToString() });
            Exercises = WorkoutContext.Exercises.Select(x => new SelectListItem() { Text = x.ToString(), Value = x.Id.ToString() });
        }
        public WorkoutItemViewModel(WorkoutItem workoutItem)
        {
            Id = workoutItem.Id;
            NumberOfSets = workoutItem.NumberOfSets;
            Equipment = workoutItem.Equipment.Id;
            Exercise = workoutItem.Exercise.Id;
            Equipments = WorkoutContext.Equipments.Select(x => new SelectListItem() { Text = x.Name, Value = x.Id.ToString() });
            Exercises = WorkoutContext.Exercises.Select(x => new SelectListItem() { Text = x.ToString(), Value = x.Id.ToString() });
        }

        public Guid Id { get; set; }
        public int NumberOfSets { get; set; }
        public int Equipment { get; set; }
        public int Exercise { get; set; }

        public Guid WorkoutId { get; set; }

        public IEnumerable<SelectListItem> Equipments { get; set; }
        public IEnumerable<SelectListItem> Exercises { get; set; }


    }
}