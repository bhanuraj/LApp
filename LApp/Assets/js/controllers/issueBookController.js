app.controller("issueBookController", ['$scope', '$http', 'issueBookService', function ($scope, $http, issueBookService) {
    $scope.UserName = "";
    $scope.Requests = "";
    $scope.SelecetdTransactionId = "";
    $scope.TransDetails = "";

    $scope.Initilize = function (model) {
        $scope.UserName = model.UserName;
        $scope.Requests = model.Requests;
    };

    $scope.IssueBook = function () {
        issueBookService.IssueBook($scope.SelecetdTransactionId);
    };

    $scope.GetTransactionDetails = function () {
        //issueBookService.IssueBook($scope.SelecetdTransactionId);
        $http.post('/Books/GetTransactionDetails', { id: parseInt($scope.SelecetdTransactionId) }).then(function (data) {
            $scope.TransDetails = data.data;
        });
    };
} ]);