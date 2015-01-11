app.controller("addBookController", ['$scope', 'addBookService', function ($scope, addBookService) {
    $scope.UserName = "";
    $scope.Name = "";
    $scope.Author = "";
    $scope.PublishedYear = "";

    $scope.Initilize = function (model) {
        $scope.UserName = model.UserName;
    };

    $scope.AddBook = function () {
        addBookService.AddBook($scope.Name, $scope.Author, $scope.PublishedYear);
    };

} ]);