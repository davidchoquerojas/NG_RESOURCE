app.controller("GpreguntaCtrl", function ($scope, AppService, AppFctry) {
    $scope.states = AppService.states();
    $scope.gpregunta = {};
    $scope.listGpregunta = [];
    //metodos
    AppFctry.getGpregunta(function (res) {
        $scope.listGpregunta = res;
    });
    $scope.save = function (gpregunta) {
        if (gpregunta.id_gpregunta == undefined) {
            AppFctry.saveGpregunta({}, gpregunta).$promise.then(function (res) {
                $scope.listGpregunta = res;
                AppService.showMessage("OK! ", "Grupo pregunta grabado correctamente.");
            });
        } else {
            AppFctry.updateGpregunta({ id: gpregunta.id_gpregunta }, gpregunta).$promise.then(function (res) {
                AppService.showMessage("OK! ", "Grupo pregunta actualizado correctamente.");
            });
        }
    }

    $scope.edit = function (gpregunta) {
        $scope.gpregunta = gpregunta;
    }
});