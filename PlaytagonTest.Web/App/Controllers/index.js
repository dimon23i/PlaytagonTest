app.controller("IndexCtrl", function ($scope, $http, $uibModal) {
    $scope.characters = [];

    $scope.add = function () {
        var model = {};

        $scope.openModal(model)
            .result.then(function (data) {
                $scope.characters.push(data);
            });
    };
    $scope.edit = function (item) {
        var model = angular.copy(item);

        $scope.openModal(model)
            .result.then(function (data) {
                angular.copy(data, item);
            });
    };
    $scope.remove = function (array, index) {
        array.remove(index);
    };
    $scope.openModal = function (model, templateId, controller) {
        templateId = templateId || 'CharacterEditor';
        controller = controller || 'ModalEditCtrl';

        return $uibModal.open({
            animation: $scope.animationsEnabled,
            templateUrl: templateId,
            controller: controller,
            size: "",
            backdrop: 'static',
            scope: $scope,
            resolve: {
                model: function () {
                    return model;
                }
            }
        });
    };
});