app.service('indexService', ['$http', function ($http) {
    var _message = "";
    this.Login = function (un, pw) {
        $http.post('/Home/Login', { userName: un, password: pw }).then(function (data) {
            if (data.data == "success")
                window.location = "/Books";
            else
                _message = data;
        });
    };
    this.getMessage = function () {
        return _message;
    }
} ]);