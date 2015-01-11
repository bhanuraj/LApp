app.controller("returnBookController", ['$scope', '$http', 'returnBookService', function ($scope, $http, returnBookService) {
    $scope.UserName = "";
    $scope.Books = "";
    $scope.SelecetdBookId = "";

    $scope.Initilize = function (model) {
        $scope.UserName = model.UserName;
        $scope.Books = model.Books;
    };

    $scope.ReturnBook = function () {
        returnBookService.ReturnBook($scope.SelecetdBookId);
    };
} ]);