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
    $scope.locations = [];
    $scope.addWorkout = function () {
        var viewModel = {};
        viewModel.Name = $scope.name;
        viewModel.Location = $scope.location;
        viewModel.WorkoutDate = $scope.workoutDate;
        viewModel.WorkoutLength = $scope.workoutLength;
        $scope.workouts.push($scope.workouts[0]);
        //$scope.editWorkout(viewModel)
    };
    //$scope.workouts = [{ workoutName: 'asdad', workoutDate: '2016-05-09' }, { workoutName: 'workout2', workoutDate: '2015-01-01' }]
    jQuery.ajax({
        url: "/Workouts/FillIndexKO",
        success: function (result) {
            $scope.workouts = result;
            $scope.locations = result[0].Locations;
        },
        async: false
    });
}]);

