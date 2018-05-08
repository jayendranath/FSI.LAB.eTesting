var hub;
var con;

function getSessionId() {
    var sessionId = window.sessionStorage.sessionId;

    if (!sessionId) {
        sessionId = window.sessionStorage.sessionId = Date.now();
    }

    return sessionId;
}