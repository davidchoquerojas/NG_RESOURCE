app.controller("ReporteCtrl", function ($scope, $location, AppFctry, AppService) {
    $scope.listEmpleado = [];
    $scope.listReporte = [];
    AppFctry.getEmpleado({ id: 0, estado:"A"}, function (res) {
        $scope.listEmpleado = res;
    });
    var asistencia = function () {
        this.id_empleado = $scope.id_empleado,
        this.fec_reg = document.getElementById("fecha_desde").value,
        this.fec_mod = document.getElementById("fecha_hasta").value
    };

    $scope.consult = function () {
        if (document.getElementById("fecha_desde").value == "")
            AppService.showMessage("Ojo. ", "Seleccione la (s) fecha");
        else if (document.getElementById("fecha_hasta").value == "")
            AppService.showMessage("Ojo. ", "Seleccione la (s) fecha");
        else {
            AppFctry.getReport({}, new asistencia()).$promise.then(function (res) {
                $scope.listReporte = res;
            });
        }
    }

    $scope.download = function () {
        if (document.getElementById("fecha_desde").value == "")
            AppService.showMessage("Ojo. ", "Seleccione la (s) fecha");
        else if (document.getElementById("fecha_hasta").value == "")
            AppService.showMessage("Ojo. ", "Seleccione la (s) fecha");
        else {
            AppFctry.exportFile({}, new asistencia()).$promise.then(function (res) {
                document.getElementById("fileDonwload").src = baseurl+"/Utils/xlsxs/" + res[0] + ".xlsx";
            });
        }
    }
});