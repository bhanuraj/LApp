app.service('SignUpService', ['$http', function ($http) {
    var _message = "";
    this.Register = function (un, em, pw) {
        $http.post('/Home/Register', { name: un, email: em, password: pw }).then(function (data) {
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