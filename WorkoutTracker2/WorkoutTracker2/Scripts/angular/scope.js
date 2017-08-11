var workoutApp = angular.module('workoutApp', []);

workoutApp.directive('mydatepicker', function () {
    return {
        restrict: 'A',
        require: 'ngModel',
        link: function (scope, element, attrs, ngModelCtrl) {
            element.datepicker({
                dateFormat: "dd-mm-yy",
                onSelect: function (date) {
                    scope.workoutDate = date;
                    scope.$apply();
                }
            });
        }
    };
});

workoutApp.controller('workoutController', ['$scope', function ($scope) {
    $scope.name = "";
    $scope.location = "";
    $scope.workoutDate = "";
    $scope.workoutLength = "";
    $scope.exercise = {};
    $scope.equipment = {};
    $scope.selectedWorkout = {};
    $scope.selectedWorkoutItem = {};
    $scope.selectedSet = {};
    $scope.locations = [];
    $scope.weight = "";
    $scope.reps = "";
    $scope.addWorkout = function () {
        var viewModel = {};
        viewModel.Name = $scope.name;
        viewModel.Location = $scope.location;
        viewModel.WorkoutDate = $scope.workoutDate;
        viewModel.WorkoutLength = $scope.workoutLength;
        viewModel.WorkoutItems = [];
        $scope.workouts.push(viewModel);
    };

    $scope.addWorkoutItem = function () {
        var viewModel = {};
        viewModel.Exercise = $scope.exercise;
        viewModel.Equipment = $scope.equipment;
        viewModel.ExerciseSets = [];
        viewModel.NumberOfSets = function () {
            return this.ExerciseSets.length;
        }
        viewModel.TotalWeight = function () {
            var totalWeight = 0;
            for (var i = 0; i < this.ExerciseSets.length; i++) {
                var set = this.ExerciseSets[i];
                totalWeight += set.numberOfRepetitions * set.equipmentWeight;
            }
            return totalWeight;
        }
        $scope.selectedWorkout.WorkoutItems.push(viewModel);
    };

    $scope.addSet = function () {
        var viewModel = {};
        viewModel.numberOfRepetitions = $scope.reps;
        viewModel.equipmentWeight = $scope.weight;
        $scope.selectedWorkoutItem.ExerciseSets.push(viewModel);
    };

    $scope.selectWorkout = function (workout) {
        $scope.selectedWorkout = workout;
    }

    $scope.selectWorkoutItem = function (workoutItem) {
        $scope.selectedWorkoutItem = workoutItem;
    }

    $scope.selectSet = function (set) {
        $scope.selectedSet = set;
    }

    $.get("/Workouts/GetEnumData", {}, function (data) {
        $scope.locations = data.Locations;
        $scope.exercises = data.Exercises;
        $scope.equipments = data.Equipments;
        $scope.muscleGroups = data.MuscleGroups;
        $scope.$apply();
        $.get("/Workouts/FillIndexKO", {}, function (data) {
            for (var i = 0; i < data.length; i++) {
                for (var j = 0; j < data[i].WorkoutItems.length; j++) {
                    data[i].WorkoutItems[j].NumberOfSets = function () {
                        return this.ExerciseSets.length;
                    };
                    data[i].WorkoutItems[j].TotalWeight = function () {
                        var totalWeight = 0;
                        for (var i = 0; i < this.ExerciseSets.length; i++) {
                            var set = this.ExerciseSets[i];
                            totalWeight += set.numberOfRepetitions * set.equipmentWeight;
                        }
                        return totalWeight;
                    };
                }
                
            }
            $scope.workouts = data;
            $scope.$apply();
        });
    });
    

}]);

