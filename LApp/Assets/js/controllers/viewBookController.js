app.controller("viewBookController", ['$scope', 'viewBookService', function ($scope, viewBookService) {
    $scope.UserName = "";
    $scope.Book = "";
    $scope.UserRole = "";

    $scope.Initilize = function (model) {
        $scope.UserName = model.UserName;
        $scope.Book = model.Book;
        $scope.UserRole = model.UserRole;
    };

    $scope.RequestBook = function (id) {
        viewBookService.RequestBook($scope.Book.BookId);
    };
} ]);