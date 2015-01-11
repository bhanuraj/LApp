app.service('issueBookService', ['$http', function ($http) {
    var _message = "";
    this.IssueBook = function (id) {
        $http.post('/Books/IssueBook', { id: id }).then(function (data) {
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