app.controller("viewBooksController", ['$scope', function ($scope) {
    $scope.UserName = "";
    $scope.Books = "";
    $scope.UserRole = "";

    $scope.Initilize = function (model) {
        $scope.UserName = model.UserName;
        $scope.Books = model.Books;
        $scope.UserRole = model.UserRole;
    };

    $scope.ShowBook = function (id) {
        window.location = "/Books/ViewBook/" + id;
    }
} ]);