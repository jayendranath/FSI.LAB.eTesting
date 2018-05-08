cordova.define("com-plugin-examineeplugin-cam.hello", function(require, exports, module) {
	
	var exec = require('cordova/exec');

	exports.LockScreen = function (arg0, success, error) {
	    exec(success, error, 'AmILate', 'LockScreen', [arg0]);
	};

	exports.ReleaseLock = function (arg0, success, error) {
	    exec(success, error, 'AmILate', 'ReleaseLock', [arg0]);
	};

});