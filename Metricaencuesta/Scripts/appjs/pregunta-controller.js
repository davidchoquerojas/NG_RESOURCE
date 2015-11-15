app.controller("PreguntaCtrl", function ($scope, AppService, AppFctry) {
    $scope.states = AppService.states();
    $scope.pregunta = {};
    $scope.listGpregunta = [];
    $scope.listPregunta = [];
    //methods
    AppFctry.getGpregunta({ estado :"A"}, function (res) {
        $scope.listGpregunta = res;
    });
    var getPregunta = function (id_Gpregunta) {
        AppFctry.getPregunta({ id: id_Gpregunta }, function (res) {
            $scope.listPregunta = res;
        });
    };
    getPregunta(0);
    $scope.save = function (pregunta) {
        if (pregunta.id_pregunta == undefined) {
            AppFctry.savePregunta({}, pregunta).$promise.then(function (res) {
                $scope.listPregunta = res;
                AppService.showMessage("OK! ", " Pregunta grabado correctamente.");
            });
        } else {
            AppFctry.updatePregunta({ id: pregunta.id_pregunta }, pregunta).$promise.then(function (res) {
                AppService.showMessage("OK! ", "Pregunta actualizado correctamente.");
            });
        }
    }

    $scope.filterGpregunta = function (id_Gpregunta) {
        getPregunta(id_Gpregunta);
    }

    $scope.edit = function (pregunta) {
        $scope.pregunta = pregunta;
    }
});