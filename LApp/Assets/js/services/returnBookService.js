app.service('returnBookService', ['$http', function ($http) {
    var _message = "";
    this.ReturnBook = function (id) {
        $http.post('/Books/ReturnBook', { id: id }).then(function (data) {
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