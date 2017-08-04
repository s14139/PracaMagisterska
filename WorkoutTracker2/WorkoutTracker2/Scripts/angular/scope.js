var workoutApp = angular.module('workoutApp', []);
workoutApp.controller('workoutController', ['$scope', function ($scope) {
    $scope.firstName = "Mary";
    $scope.lastName = "Jane";
    $.get("/Workouts/FillIndexKO", {}, function (data) {
        $scope.workouts = data;
    });
}]);