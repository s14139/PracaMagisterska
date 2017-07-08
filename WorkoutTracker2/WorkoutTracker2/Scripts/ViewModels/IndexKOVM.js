// This is a simple *viewmodel* - JavaScript that defines the data and behavior of your UI
//function AppViewModel() {
//    this.firstName = ko.observable("Bert");
//    this.lastName = ko.observable("Bertington");
//}

//// Activates knockout.js
//ko.applyBindings(new AppViewModel());

var urlPath = window.location.pathname;
var urlWithoutIndex = urlPath.substring(0, urlPath.lastIndexOf("/") + 1);
var completeUrl = urlWithoutIndex + '/FillIndexKO';

$(function () {
    ko.applyBindings(indexVM);
    indexVM.loadWorkouts();
});

var indexVM = {
    Workouts: ko.observableArray([]),

    loadWorkouts: function () {
        var self = this;
        debugger;
        //Ajax Call Get All Articles
        $.ajax({
            type: "GET",
            url: completeUrl,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                self.Workouts(data); //Put the response in ObservableArray
            },
            error: function (err) {
                alert(err.status + " : " + err.statusText);
            }
        });

    }
};

function Workouts(Workouts) {
    this.WorkoutLength = ko.observable(Workouts.WorkoutLength);
    this.WorkoutDate = ko.observable(Workouts.WorkoutDate);
    this.Location = ko.observable(Workouts.Location);
}