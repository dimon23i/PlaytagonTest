app.controller('ModalEditCtrl', ['$scope', '$modalInstance', 'model', '$http', function ($scope, $modalInstance, model, $http) {
    $scope.model = model;

    $scope.ok = function () {
        var data = JSON.stringify($scope.model);
        $http.put('/api/character', data).then(function (data) {
            $modalInstance.close($scope.model);
        });
    };
    $scope.cancel = function () {
        $modalInstance.dismiss('cancel');
    };
}]);