app.controller('ModalEditCtrl', ['$scope', '$modalInstance', 'model', '$http', function ($scope, $modalInstance, model, $http) {
    $scope.model = model;

    $scope.ok = function () {
        var data = JSON.stringify($scope.model);
        $http.put('/api/character', data).then(function (data) {
            $modalInstance.close($scope.model);
        },
        function(error) {
            _showValidationErrors(error);
        });
    };
    $scope.cancel = function () {
        $modalInstance.dismiss('cancel');
    };
    function _showValidationErrors(error) {
        $scope.validationErrors = [];
        if (error.data && angular.isObject(error.data.ModelState)) {
            for (var key in error.data.ModelState) {
                var fieldName = key.split('.');
                $scope.validationErrors.push(fieldName[fieldName.length-1] + ": " + error.data.ModelState[key][0]);
            }
        } else {
            $scope.validationErrors.push('Could not add character.');
        };
    }
}]);