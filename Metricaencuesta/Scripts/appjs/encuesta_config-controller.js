app.controller("EncuestaConfigCtrl", function ($scope, $location, AppFctry, AppService) {
    $scope.statesE = AppService.statesE();
    $scope.listEncCon = [];
    $scope.enccon = {};
    $scope.enccon.estado = "C";

    //methods
    AppFctry.getEncuestaConfig(function (res) {
        $scope.listEncCon = res;
    });

    $scope.save = function (enccon) {
        if (enccon.id_encuesta == undefined) {
            AppFctry.saveEncuestaConfig({}, enccon).$promise.then(function (res) {
                if (res.length > 0) {
                    $scope.listEncCon = res;
                    AppService.showMessage("OK! ", "Encuesta grabado correctamente.");
                }
            });
        } else {
            AppFctry.updateEncuestaConfig({ id: enccon.id_encuesta }, enccon).$promise.then(function (res) {
                if (res.length > 0) {
                    $scope.listEncCon = res;
                    AppService.showMessage("OK! ", "Encuesta actualizado correctamente.");
                }
            });
        }
        $scope.enccon = {};
    }
    $scope.edit = function (enccon) {
        $scope.enccon.id_encuesta = enccon.id_encuesta;
        $scope.enccon.fecha_ini = setFormatDate(enccon.fecha_ini);
        $scope.enccon.fecha_fin = setFormatDate(enccon.fecha_fin);
        $scope.enccon.estado = enccon.estado;
    }

    function setFormatDate(date) {
       return  new Date(parseInt(date.substr(6)));
    }
});