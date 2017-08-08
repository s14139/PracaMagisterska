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
    $scope.locations = [];
    $scope.addWorkout = function () {
        var viewModel = {};
        viewModel.Name = $scope.name;
        viewModel.Location = $scope.location;
        viewModel.WorkoutDate = $scope.workoutDate;
        viewModel.WorkoutLength = $scope.workoutLength;
        $scope.workouts.push(viewModel);
        //$scope.editWorkout(viewModel)
    };
    $.get("/Workouts/GetEnumData", {}, function (data) {
        $scope.locations = data.Locations;
        $scope.exercises = data.Exercises;
        $scope.equipments = data.Equipments;
        $scope.muscleGroups = data.MuscleGroups;
        $scope.$apply();
        $.get("/Workouts/FillIndexKO", {}, function (data) {
            $scope.workouts = data;
            $scope.$apply();
        });
    });
    

}]);

