/// <reference path=angular.min.js" />
//$scope.assessments = [
//    { 'id': 10, 'name': 'Pilot Assessment 1' },
//    { 'id': 27, 'name': 'Pilot Assessment 2' },
//    { 'id': 39, 'name': 'Pilot Assessment 3' },
//]

//$scope.assessmentsdata = {
//    'id': 1,
//    'assessments': 27
//}
function padDigits(number, digits) {
    return Array(Math.max(digits - String(number).length + 1, 0)).join(0) + number;
}

var appProctor = angular.module('appProctor', []);
appProctor.directive('onFinishRender', function ($timeout) {
    return {
        restrict: 'A',
        scope:false,
        link: function (scope, element, attr) {
            if (scope.$last === true) {
                $timeout(function () {
                    scope.$emit(attr.onFinishRender);
                });
            }
        }
    }
});

appProctor.directive('compile', function ($compile) {
    // directive factory creates a link function
    return function (scope, element, attrs) {
        scope.$watch(

        function (scope) {
            // watch the 'compile' expression for changes
            return scope.$eval(attrs.compile);
        },

        function (value) {
            // when the 'compile' expression changes
            // assign it into the current DOM
            element.html(value);

            // compile the new DOM and link it to the current
            // scope.
            // NOTE: we only compile .childNodes so that
            // we don't get into infinite loop compiling ourselves
            $compile(element.contents())(scope);
        });
    };
})

appProctor.controller("conProctor", function ($scope, $http, $compile) {
    //var assessmentid = "";
    //$scope.assessmentid = function (id) { assessmentid = id };
    $scope.ProctorInit = function () {
        //$http.get('../WebServices/Proctoring.asmx/GetAssessments')
        //.then(function (response) {
        //    $scope.assessments = response.data;

        //});

    };
    $scope.changedValue = function (apiSiteURL, ExamScheduleId, Proctorid) {
        //var item = $scope.assessmentid;
        //assessmentid = 1;
        //$http.get('../WebServices/Proctoring.asmx/GetExamineesForSelectedAssessment?assessmentid=' + assessmentid)
        $http.get(apiSiteURL + '/api/examsession/' + ExamScheduleId + '/' + Proctorid + '/examinees')
            .then(function (response) {
                //$scope.examinees = response.data;
                examineesdata(response.data);
            });
    }.bind($scope);

    $scope.ProctorReivewInit = function (assessmentid) {
        //var item = $scope.assessmentid;
        $http.get('../WebServices/Proctoring.asmx/GetExamineesForSelectedAssessment?assessmentid=' + assessmentid)
            .then(function (response) {
                $scope.examinees = response.data;
                //examineesdata(response.data);
            });
    }.bind($scope);

    $scope.getAllUsers = function () {
        //var item = $scope.assessmentid;
        $http.get('../WebServices/Proctoring.asmx/GetAllUsers')
            .then(function (response) {
                $scope.allusers = response.data;
                //examineesdata(response.data);
            });
    }.bind($scope);

    $scope.ExamSchedulersInit = function (stpath) {
        $http.get(stpath + '/Home/GetExamSchedules') //../WebServices/Proctoring.asmx/GetExamSchedules
        .then(function (response) {
            $scope.examschudules = response.data;

        });
    }

    $scope.GetCenters = function (webAPIURL) {
        $http.get(webAPIURL + '/api/centers')
        .then(function (response) {
            $scope.centerlist =response.data;
        });
    }

    

    //******=========Get Single ExamSchedule=========******
    $scope.GetExamScheduler = function (webAPIURL, sid) {
        $http.get(webAPIURL + '/api/examschedule/' + sid)
        .then(function (response) {
            $scope.ScheduleId = response.data.ExamScheduleId;
            $scope.Course = response.data.Course;
            $scope.AssessmentId = response.data.AssessmentId;
            $scope.AssessmentTitle = response.data.AssessmentTitle;
            $scope.ProgramTitle = response.data.ProgramTitle;
            $scope.TempProgramId = response.data.ProgramId;
            var sdate = new Date(response.data.ScheduleDate);
            var day = padDigits(sdate.getDate(),2); //Date of the month: 2 in our example
            var month = padDigits(sdate.getMonth(),2); //Month of the Year: 0-based index, so 1 in our example
            var year = sdate.getFullYear() //Year: 2013
            $scope.ScheduleTime = sdate.getHours() + ':' + sdate.getMinutes();
            $scope.ScheduleDate = month + '/' + month + '/' + year;
            $scope.PassPercentage = response.data.PassPercentage;
            $scope.Duration = response.data.Duration;
            $scope.RoomNumber = response.data.RoomNumber;
            $scope.ProctorUserName = response.data.ExamScheduleProctorEntities[0].ProctorName;
            $scope.ProctorUserId = response.data.ExamScheduleProctorEntities[0].ProctorId;
            $scope.ExamScheduleProctorEntitiesId = response.data.ExamScheduleProctorEntities[0].Id;
            $scope.LearningCenterId = response.data.LearningCenterId;
            //$scope.ExamineeEntities = response.data.ExamineeEntities;
            loadClient(response.data.ExamineeEntities);
        })
    };
    $scope.formateddate = function (dt) {
        var iStart = dt.indexOf("(");
        var iEnd = dt.indexOf(")");
        var res = dt.substring(iStart+1, iEnd);
        return res;
    }
    $scope.validateLogin = function (txtID,sturl) {
        $http.get('../WebServices/Proctoring.asmx/validateProctorLogin?stid=' + txtID)
            .then(function (response) {
                if (response.data.UserId === 0) {
                    alert("User not found. Please try again ...");
                }
                else {
                    $scope.user = response.data;
                    if (response.data.RoleId != 1)
                        alert("Login is not Proctor. Please try again ...");
                    else {
                        window.location.href = (sturl + "/home/proctordashboard");
                        
                    }
                }
            });
    }
    $scope.$on('ngRepeatFinished', function (ngRepeatFinishedEvent) {
        //you also get the actual event object
        //do stuff, execute functions -- whatever...
        abc();
        setExamineeStatus();
    });
});


