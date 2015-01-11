app.controller("indexController", ['$scope', 'indexService', function ($scope, indexService) {
    $scope.UserName = "";
    $scope.Password = "";
    $scope.Message = "";

    $scope.Login = function () {
        indexService.Login($scope.UserName, $scope.Password);
        $scope.Message = indexService.getMessage();
        var asa = "";
    };
} ]);