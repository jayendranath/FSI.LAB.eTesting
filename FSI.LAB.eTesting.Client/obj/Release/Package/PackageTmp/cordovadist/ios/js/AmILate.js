var exec = require('cordova/exec');

//exports.coolMethod = function (arg0, success, error) {
//    exec(success, error, 'AmILate', 'coolMethod', [arg0]);
//};

exports.LockScreen = function (arg0, success, error) {
    exec(success, error, 'AmILate', 'LockScreen', [arg0]);
};

exports.ReleaseLock = function (arg0, success, error) {
    exec(success, error, 'AmILate', 'ReleaseLock', [arg0]);
};