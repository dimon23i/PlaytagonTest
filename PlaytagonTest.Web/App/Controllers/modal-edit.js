app.controller('ModalEditCtrl', ['$scope', '$modalInstance', 'model', function ($scope, $modalInstance, model) {
    $scope.model = model;

    $scope.ok = function () {
        $modalInstance.close($scope.model);
    };
    $scope.cancel = function () {
        $modalInstance.dismiss('cancel');
    };
}]);