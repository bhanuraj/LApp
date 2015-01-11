app.service('viewBookService', ['$http', function ($http) {
    var _message = "";
    this.RequestBook = function (id) {
        $http.post('/Books/RequestBook', { id: id }).then(function (data) {
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