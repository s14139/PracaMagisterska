var workoutApp = angular.module('workoutApp', []);
workoutApp.controller('workoutController', ['$scope', function ($scope) {

    $.get("/Workouts/FillIndexKO", {}, function (data) {
        $scope.workouts = data;
    });
    
}]);