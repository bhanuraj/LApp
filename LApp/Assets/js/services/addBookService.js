app.service('addBookService', ['$http', function ($http) {
    var _message = "";
    this.AddBook = function (name, author, py) {
        $http.post('/Books/AddBook', { name: name, author: author, publishedYear: py }).then(function (data) {
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