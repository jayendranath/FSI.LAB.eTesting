//var myApp = angular.module('appExaminee', []);

//function ctrlExamniee($scope) {
//var con = $.hubConnection('http://localhost:52202/');http://localhost/eLearning
//var hub = con.createHubProxy('chatHub');
var appExaminee = angular.module('appExaminee', []);
//appExaminee.value('$', $);
appExaminee.directive('onFinishRender', function ($timeout) {
    return {
        restrict: 'A',
        link: function (scope, element, attr) {
            if (scope.$last === true) {
                $timeout(function () {
                    scope.$emit(attr.onFinishRender);
                });
            }
        }
    }
});

appExaminee.factory('ProctorService', ['$rootScope', function ($rootScope) {

    return {
        connect: function () {
            //hub.on('StartExam', function (grpName, ProctorId) {
            //    // Html encode display name and message.
            //    // Add the message to the page.
            //    debugger;
            //    //populatedtable(grpName, ProctorId);
            //    startExamHub(grpName, ProctorId);
            //    //$('#\').prop('disabled', false);
            //});
            hub.on('broadcastMessage', function (msg) {
                // Html encode display name and message.
                // Add the message to the page.
                sendMessage(msg);
                //$('#startexam').prop('disabled', false);
            });
            hub.on('CheckAndAddExaminee', function (grpName, ProctorId) {
                //CheckAndAdd();
                populatedtable(grpName, ProctorId);
            });
        },
        isConnecting: function () {
            return con.state === 0;
        },
        isConnected: function () {
            return con.state === 1;
        },
        connectionState: function () {
            return con.state;
        },
        connectProctor: function (grpname, name) {
            //con.start({ transport: ['webSockets', 'serverSentEvents', 'longPolling'] });
            hub.invoke("JoinExamGroup", grpname, name, "Examinee");
            //hub.invoke("JoinExamGroup");
            //hub.invoke('SendInvidualMsg', grpname);
        },
        startedExam: function (grpname, name, ProctorID) {
            hub.invoke("StartedExam", grpname, name, ProctorID);
            //hub.invoke("startExam");
        },
        //pausedExam: function (name) {
        //    hub.invoke("PausedExam", name);
        //},
        endedExam: function (name) {
            hub.invoke("EndedExam", name);
        },
        addExamineeAfterExamStarted: function (grpname, name, ProctorID, ip, compname) {
            hub.invoke("AddUserAfterExamStarted", grpname, name, ProctorID, ip, compname);
        }
    }
}]);

appExaminee.controller("ctrlExamniee", function ($scope, $http, ProctorService) {
    $scope.examinee = null;
    ProctorService.connect();
    //$scope.ExamineeInit = function () {
    //   LoadExaminee();
    //}
    $scope.getExaminee = function (input, siteURL, steid) {
        var WebApiBaseUri = siteURL + '/api/examinee/' + steid + '/exams';
        $http.get(WebApiBaseUri)
               .then(function (response) {
                   $scope.examinee = input;
                   for (var i = 0; i < response.data.length; i++) {
                       try {
                           if (response.data[i].ExamineeRefId.toLowerCase() == input.toLowerCase()) {
                               ProctorService.connectProctor(response.data[i].Course, input);
                           }
                       }
                       catch (err) { alert("connect proctor:" + err) }
                   }
               })
    }

    $scope.AssessmentQuestionsLoad = function (item) {
        $scope.assessmentid = item;
        $http.get('../WebServices/Proctoring.asmx/GetAssessmentQuestions?assessmentId=' + item)
            .then(function (response) {
                $scope.assessmentquestion = response.data;
            });
    }

    //$scope.validateExamineeLogin = function (txtID, siteURL) {
    //    $http.get(siteURL + '/WebServices/Proctoring.asmx/validateUser?stid=' + txtID)
    //        .then(function (response) {
    //            if (response.data.UserId === 0) {
    //                alert("User not found. Please try again ...");
    //            }
    //            else {
    //                $scope.user = response.data;
    //                if (response.data.RoleId != 2)
    //                    alert("Login is not Examinee. Please try again ...");
    //                else {
    //                    window.location.href = ("/home/examinee");
    //                }
    //            }
    //        });
    //}

    $scope.ExamSchedulerDetailsLoad = function (item) {
        $scope.scheduleId = item;
        $http.get('../WebServices/Proctoring.asmx/GetExamScheduleDetailsById?scheduleId=' + item)
            .then(function (response) {
                $scope.examschudule = response.data;
            });
    }

    $scope.$on('ngRepeatFinished', function (ngRepeatFinishedEvent) {
        //you also get the actual event object
        //do stuff, execute functions -- whatever...
        setExamStartStatus1();
    });
    $scope.startedexam = function (examName, ProctorID) {
        ProctorService.startedExam(examName, $scope.examinee, ProctorID);
    }

    //$scope.pausedexam = function () {
    //    ProctorService.pausedExam($scope.examinee);
    //}

    $scope.endedexam = function () {
        ProctorService.endedExam($scope.examinee);
    }

    $scope.addexaminee = function (examName, ProctorID, ip, compname, username) {
        ProctorService.addExamineeAfterExamStarted(examName, username, ProctorID, ip, compname);
    }

    $scope.getExamineeReviewExam = function () {
        reviewrecords = [
        {
            "AssessmentId": "2EFE2DDF-1D64-452D-A4A0-CB8807AB0FB3",
            "AssessmentTitle": "Pilot-Bombardier CL605 66555",
            "Course": "Pilot-Bombardier CL605",
            "CourseType": "Pilot",
            "StartedAt": "08-31-2017 10:30 AM CST",
            "NoOfQuestions": 50,
            "CorrectResponses": "50 (100%)",
            "IncorrectResponses": "0 (0%)",
            "SkippedQuestions": "0 (0%)",
            "Result": "Pass",
            //"status": '<i title="Scored to 100%" class="fa fa-fw fa-check fa-2x" style="color:green">',
            "Review": ""
            //"title": "Scored to 100%"
        }, {
            "AssessmentId": "7731569D-162D-426E-8170-4FAE129224BE",
            "AssessmentTitle": "MX-Beech 200 Series (PWC PT6) MI EMX11061140602",
            "Course": "Beech KA 300 Series Familiarization 4 Days - Theory (EASA, UAE)  - Wichita - 28-Nov-17",
            "CourseType": "Maintenance",
            "StartedAt": "08-10-2017 10:30 AM CST",
            "NoOfQuestions": 50,
            "CorrectResponses": "45 (90%)",
            "IncorrectResponses": "3 (6%)",
            "SkippedQuestions": "2 (4%)",
            "Result": "Pass",
            //"status": '<i title="Reviewed to 100%" class="fa fa-fw fa-check fa-2x" style="color:orange">',
            //href="@Url.Action("ExamReview", "Home")?title=' + item.ExamTitle + '&exID=@GlobalVariables.LoginID&exname=@GlobalVariables.LoginID"
            "Review": '<i title="Reviewed to 100%" class="fa fa-fw fa-check fa-2x" style="color:green">'
            //"title":"Reviewed to 100%"
        },
        {
            "AssessmentId": "7731569D-162D-426E-8170-4FAE129224BE",
            "AssessmentTitle": "MX-Beech 200 Series (PWC PT6) MI EMX11061140602",
            "Course": "Beech KA 300 Series Familiarization 4 Days - Theory (EASA, UAE)  - Wichita - 11-Dec-17",
            "CourseType": "Maintenance",
            "StartedAt": "12-11-2017 9:00 AM CST",
            "NoOfQuestions": 50,
            "CorrectResponses": "45 (90%)",
            "IncorrectResponses": "3 (6%)",
            "SkippedQuestions": "2 (4%)",
            "Result": "Pass",
            //"status": '',
            //"Review": '<div><a id="ancReview" target="_blank" title="Start Review" ><img src="../Images/Review_Disable.png? + @DateTime.Now.Ticks.ToString()" height="30" width="30"/></a></div>'
            "Review": '<div><a id="ancReview" title="Start Review" ><img src="../Images/Review_Disable.png? + @DateTime.Now.Ticks.ToString()" height="30" width="30"/></a></div>'
            //"title": ""
        },
        {
            "AssessmentId": "9DD11EA2-9081-4F2B-90F1-8D19BB3B99A6",
            "AssessmentTitle": "Pilot-G200-DFW PR11080212115",
            "Course": "Pilot-G200-DFW PR11080212115",
            "CourseType": "Pilot",
            "StartedAt": "12-11-2017 9:30 AM CST",
            "NoOfQuestions": 50,
            "CorrectResponses": "25 (50%)",
            "IncorrectResponses": "25 (50%)",
            "SkippedQuestions": "0 (0%)",
            "Result": "Fail",
            //"status": '',
            "Review": ""
            //"title": ""
        }
        ]
        LoadCompletedExamData(reviewrecords);
    }

    $scope.getExamineePausedExam = function () {
        reviewrecords = [
        {
            "AssessmentId": "2EFE2DDF-1D64-452D-A4A0-CB8807AB0FB3",
            "AssessmentTitle": "Pilot-Bombardier CL605 66555",
            "Course": "Pilot-Bombardier CL605",
            "CourseType": "Pilot",
            "StartedAt": "08-31-2017 10:30 AM CST",
            "NoOfQuestions": 50,
            "Answered": 35,
            "UnAnswered": 15,
            "Bookmarked": 9,
            "Duration": 180,
            "RemTime": 35
        }
        ]
        LoadPausedExamData(reviewrecords);
    }
    //window.populatedtable();
})