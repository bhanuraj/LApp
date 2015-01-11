app.controller("SignUpController", ['$scope', 'SignUpService', function ($scope, SignUpService) {
    $scope.Name = "";
    $scope.Email = "";
    $scope.Password = "";

    $scope.Register = function () {
        SignUpService.Register($scope.Name, $scope.Email, $scope.Password);
        $scope.Message = SignUpService.getMessage();
        var asa = "";
    };
} ]);