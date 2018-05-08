/// <reference path="typings/cordova/cordova.d.ts" />
/// <reference path="typings/cordova/plugins/Camera.d.ts" />
var CordovaHostedApp;
(function (CordovaHostedApp) {
    "use strict";
    var Application;
    (function (Application) {
        function initialize() {
            //alert("in app initialize");

            onDeviceReady();
            //this.document.addEventListener('deviceready', this.onDeviceReady, false);
        }
        Application.initialize = initialize;
        function onDeviceReady() {
            //alert("app initialized");
            // Handle the Cordova pause and resume events
            document.addEventListener('pause', onPause, false);
            document.addEventListener('resume', onResume, false);
            document.getElementsByClassName('btn-lg')[0].addEventListener('mousedown', takePicture);
            

            //try {
            //    var mp = cordova.require("com-plugin-examineeplugin.hello");
            //    if (mp) {
            //        alert("In webapp: AmILate plugin Found !");
            //    }
            //    else {
            //        alert("In webapp: AmILate plugin NOT Found !");
            //    }
            //    var win = function () { alert('Win! Successfully called method!'); }
            //    var fail = function () { alert('fail!'); }
            //    mp.coolMethod('Are you ok?', win, fail);
            //}
            //catch (error) {
            //    alert("Error calling method!");
            //    alert("I guess not ok" + error);
            //}

            //try {
            //    alert('taking picture');
            //    takePicture();
            // }
            //catch (error) {
            //    alert(error);
            //}
            //document.getElementsByName('btnTest')[0].addEventListener('click', sayHello1);
        }

        function takePicture() {
            if (!navigator.camera) {
                alert("Camera API not supported");
                return;
            }
            var options = {
                quality: 20,
                destinationType: Camera.DestinationType.DATA_URL,
                sourceType: 1,
                encodingType: 0
            };
            navigator.camera.getPicture(function (imgData) {
                var el;
                el = document.getElementsByClassName('media-object')[0];
                var srcAttr = document.createAttribute("src");
                srcAttr.value = "data:image/jpeg;base64," + imgData;
                el.attributes.setNamedItem(srcAttr);
            }, function () {
                alert('Error taking picture');
            }, options);
            return false;
        }
        function onPause() {
        }
        function onResume() {
        }
    })(Application = CordovaHostedApp.Application || (CordovaHostedApp.Application = {}));
    window.onload = function () {
        //alert("before app initialize");

        Application.initialize();

    };
})(CordovaHostedApp || (CordovaHostedApp = {}));
