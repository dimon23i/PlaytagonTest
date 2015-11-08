app.controller("IndexCtrl", function ($scope, $http, $uibModal) {
    $scope.model = {};
    $scope.itemsPerPage = 5;
    $scope.currentPage = 1;

    var init = function () {
        $http.get("/api/character").then(function (responce) {
            $scope.model.characters = responce.data;

            $scope.$watch('currentPage + itemsPerPage + model.characters', function () {
                $scope.totalItems = $scope.model.characters.length;
                var begin = (($scope.currentPage - 1) * $scope.itemsPerPage),
                    end = begin + $scope.itemsPerPage;

                $scope.filteredCharacters = $scope.model.characters.slice(begin, end);
            });
        });
    };
    init();

    $scope.add = function () {
        var model = {};

        $scope.openModal(model)
            .result.then(function (data) {
                $scope.model.characters.push(data);
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
        $http.delete("/api/character/" + array[index].Id).then(function () {
            array.splice(index, 1);
        });
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