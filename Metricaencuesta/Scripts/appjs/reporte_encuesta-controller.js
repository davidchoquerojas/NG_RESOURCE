app.controller("ReporteCtrl", function ($scope, $location, AppFctry, AppService) {
    var resultado = function () {
        this.fec_reg = document.getElementById("fecha_desde").value,
        this.fec_mod = document.getElementById("fecha_hasta").value
    };

    $scope.download = function () {
        
        if (document.getElementById("fecha_desde").value == "")
            AppService.showMessage("Ojo. ", "Seleccione la fecha inicio");
        else if (document.getElementById("fecha_hasta").value == "")
            AppService.showMessage("Ojo. ", "Seleccione la (s) fecha fin");
        else {
            AppFctry.exportFileEncuesta({type:$scope.type}, new resultado()).$promise.then(function (res) {
                document.getElementById("fileDonwload").src = baseurl+"/Utils/xlsxs/" + res[0] + ".xlsx";
            });
        }
    }
});