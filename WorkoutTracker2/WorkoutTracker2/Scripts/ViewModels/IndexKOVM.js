// This is a simple *viewmodel* - JavaScript that defines the data and behavior of your UI
//function AppViewModel() {
//    this.firstName = ko.observable("Bert");
//    this.lastName = ko.observable("Bertington");
//}

//// Activates knockout.js
//ko.applyBindings(new AppViewModel());

var urlPath = window.location.pathname;
var urlWithoutIndex = urlPath.substring(0, urlPath.lastIndexOf("/") + 1);
var wokroutListUrl = urlWithoutIndex + '/FillIndexKO';
var locationListUrl = urlWithoutIndex + "/GetLocations"

     

function WorkoutViewModel(workoutDate, workoutLength, location) {
    var self = this;
    self.WorkoutDate = ko.observable(workoutDate);
    self.WorkoutLength = ko.observable(workoutLength);
    self.Location = location;
}

function Location(id, location) {
    var self = this;
    self.Id = ko.observable(id);
    self.Name = ko.observable(location);
}

function IndexViewModel() {
    var self = this;
    self.workoutDate = ko.observable();
    self.workoutLength = ko.observable();
    self.location = ko.observable();   
    self.addWorkout = function () {
        self.Workouts.push(
            new WorkoutViewModel(
                self.workoutDate(),
                self.workoutLength(),
                self.location()
            )
        );
    };
    self.locations = ko.observableArray();
    self.Workouts = ko.observableArray();
    $.get(locationListUrl, {}, self.locations);
    $.get(wokroutListUrl, {}, self.Workouts);
}

ko.applyBindings(new IndexViewModel());
$("#datepicker").datepicker({
    dateFormat: "dd-mm-yy"
});
//function Workouts(Workouts) {
//    this.WorkoutLength = ko.observable(Workouts.WorkoutLength);
//    this.WorkoutDate = ko.observable(Workouts.WorkoutDate);
//    this.Location = ko.observable(Workouts.Location);
//}