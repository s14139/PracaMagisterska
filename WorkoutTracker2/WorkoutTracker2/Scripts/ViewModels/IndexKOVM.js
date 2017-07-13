var urlPath = window.location.pathname;
var urlWithoutIndex = urlPath.substring(0, urlPath.lastIndexOf("/") + 1);
var wokroutListUrl = urlWithoutIndex + '/FillIndexKO';
var locationListUrl = urlWithoutIndex + "/GetLocations"

function SetupDatePicker() {
    $(".datepicker").datepicker({
        dateFormat: "dd-mm-yy"
    });
}
     
function WorkoutViewModel(data) {
    var self = this;

    if (!data) {
        data = {};
    }
    self.id = ko.observable(data.Id);
    self.name = ko.observable(data.Name);
    self.location = ko.observable(data.Location);
    self.workoutDate = ko.observable(data.WorkoutDate);
    self.workoutItems = ko.observableArray(data.WorkoutItems);
    self.workoutLength = ko.observable(data.WorkoutLength);
    self.userId = ko.observable(data.UserId);
    self.locations = ko.observableArray(data.Locations);
};

function Location(id, location) {
    var self = this;
    self.Id = ko.observable(id);
    self.Name = ko.observable(location);
}

function IndexViewModel() {
    var self = this;
    self.selectedWorkout = ko.observable();
    self.name = ko.observable();
    self.workoutDate = ko.observable();
    self.workoutLength = ko.observable();
    self.location = ko.observable();   
    self.addWorkout = function () {
        var viewModel = new WorkoutViewModel();
        viewModel.name(self.name())
        viewModel.location(self.location())
        viewModel.workoutDate(self.workoutDate())
        viewModel.workoutLength(self.workoutLength())
        self.Workouts.push(viewModel);
        SetupDatePicker();
    };
    self.editWorkout = function (workout) {
        self.selectedWorkout(workout);
    }
    self.locations = ko.observableArray();
    self.Workouts = ko.observableArray();
    $.get(locationListUrl, {}, self.locations);
    $.get(wokroutListUrl, {}, function (data) {
        for (var i = 0; i < data.length; i++) {
        self.Workouts.push(
           new WorkoutViewModel(data[i])
       );
        }
    });
}

ko.applyBindings(new IndexViewModel());
SetupDatePicker();


//function Workouts(Workouts) {
//    this.WorkoutLength = ko.observable(Workouts.WorkoutLength);
//    this.WorkoutDate = ko.observable(Workouts.WorkoutDate);
//    this.Location = ko.observable(Workouts.Location);
//}