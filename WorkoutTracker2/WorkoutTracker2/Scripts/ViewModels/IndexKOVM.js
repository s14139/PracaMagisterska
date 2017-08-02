var urlPath = window.location.pathname;
var urlWithoutIndex = urlPath.substring(0, urlPath.lastIndexOf("/") + 1);
var wokroutListUrl = urlWithoutIndex + '/FillIndexKO';
var locationListUrl = urlWithoutIndex + "/GetEnumData"

function SetupDatePicker() {
    $(".datepicker").datepicker({
        dateFormat: "dd-mm-yy"
    });
}

var ExerciseSetViewModel = function (data) {
    var self = this;

    if (!data) {
        data = {};
    }
    self.id = ko.observable(data.Id);
    self.numberOfRepetitions = ko.observable(data.numberOfRepetitions);
    self.equipmentWeight = ko.observable(data.equipmentWeight);
}

var WorkoutItemViewModel = function (data) {
    var self = this;

    if (!data) {
        data = {};
    }

    self.id = ko.observable(data.Id);
    self.exercise = ko.observable(data.Exercise);
    self.equipment = ko.observable(data.Equipment);
    self.exerciseSets = ko.observableArray();
    if (data.ExerciseSets != null) {
        for (var i = 0; i < data.ExerciseSets.length; i++) {
            var exerciseSet = data.ExerciseSets[i];
            self.exerciseSets.push(new ExerciseSetViewModel(exerciseSet));
        }
    }
    self.numberOfSets = ko.computed(function () {
        return self.exerciseSets().length;
    });
    self.totalWeight = ko.computed(function () {
        var total = 0;
        var sets = self.exerciseSets();
        for (var i = 0; i < sets.length; i++) {
            total += sets[i].numberOfRepetitions() * sets[i].equipmentWeight();
        }
        return total;
    });
};

function WorkoutViewModel(data) {
    var self = this;

    if (!data) {
        data = {};
    }
    self.id = ko.observable(data.Id);
    self.name = ko.observable(data.Name);
    self.location = ko.observable(data.Location);
    self.workoutDate = ko.observable(data.WorkoutDate);
    self.workoutLength = ko.observable(data.WorkoutLength);
    self.userId = ko.observable(data.UserId);
    self.workoutItems = ko.observableArray();
    if (data.WorkoutItems != null) {
        for (var i = 0; i < data.WorkoutItems.length; i++) {
            var workoutItem = data.WorkoutItems[i];
            self.workoutItems.push(new WorkoutItemViewModel(workoutItem));
        }
    }

};



function Location(id, location) {
    var self = this;
    self.Id = ko.observable(id);
    self.Name = ko.observable(location);
}

function IndexViewModel() {
    var self = this;
    self.selectedWorkout = ko.observable();
    self.selectedWorkoutItem = ko.observable();
    self.name = ko.observable();
    self.workoutDate = ko.observable();
    self.workoutLength = ko.observable();

    self.location = ko.observable();
    self.exercise = ko.observable();
    self.equipment = ko.observable();
    self.muscleGroup = ko.observable();

    self.equipmentWeight = ko.observable();
    self.numberOfRepetitions = ko.observable();

    self.addWorkout = function () {
        var viewModel = new WorkoutViewModel();
        viewModel.name(self.name())
        viewModel.location(self.location())
        viewModel.workoutDate(self.workoutDate())
        viewModel.workoutLength(self.workoutLength())
        self.Workouts.push(viewModel);
        SetupDatePicker();
        self.editWorkout(viewModel)
    };

    self.addWorkoutItem = function () {
        var viewModel = new WorkoutItemViewModel();
        viewModel.exercise(self.exercise())
        viewModel.equipment(self.equipment())
        self.selectedWorkout().workoutItems.push(viewModel);
    };

    self.addSet = function () {
        var viewModel = new ExerciseSetViewModel();
        viewModel.equipmentWeight(self.equipmentWeight())
        viewModel.numberOfRepetitions(self.numberOfRepetitions())
        self.selectedWorkoutItem().exerciseSets.push(viewModel);
    };


    self.editWorkout = function (workout) {
        self.selectedWorkout(workout);
        if (workout.exerciseSets != null && workout.exerciseSets.length > 0) {
            self.selectedWorkoutItem(workout.exerciseSets[0]);
        }
        else {
            self.selectedWorkoutItem(null);
        }
        
    }

    self.editWorkoutItem = function (workoutItem) {
        self.selectedWorkoutItem(workoutItem);
    }

    self.numberOfSets = ko.computed(function (workoutItem) {
        var total = 0;
        if (workoutItem != null && workoutItem.exerciseSets() != null) {
            total = workoutItem.exerciseSets().length

        }
        return total;
    });



    self.locations = ko.observableArray();
    self.exercises = ko.observableArray();
    self.equipments = ko.observableArray();
    self.muscleGroups = ko.observableArray();

    self.Workouts = ko.observableArray();
    $.get(locationListUrl, {}, function (data) {
        self.locations(data.Locations);
        self.exercises(data.Exercises);
        self.equipments(data.Equipments);
        self.muscleGroups(data.MuscleGroups);
    });
    $.get(wokroutListUrl, {}, function (data) {
        for (var i = 0; i < data.length; i++) {
            self.Workouts.push(
               new WorkoutViewModel(data[i])
           );
            if (i == data.length -1) {
                self.editWorkout(self.Workouts()[i])
            }
        }
    });
}

ko.applyBindings(new IndexViewModel());
SetupDatePicker();
