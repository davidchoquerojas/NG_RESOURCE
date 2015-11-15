app.controller("EmpleadoCtrl", function ($scope, AppService, AppFctry) {
    $scope.states = AppService.states();
    $scope.userType = AppService.userType();
    $scope.listEmpleado = [];
    $scope.empleado = {};
    $scope.empleado.estado = "A";
    $scope.disabled = true;
    //metodos
    AppFctry.getEmpleado({ id: 0 }, function (res) {
        $scope.listEmpleado = res;
    });
    $scope.editUser = function (empleado) {
        $scope.disabled = false;
        $scope.empleado = empleado;
    }

    $scope.save = function (empleado) {
        if (empleado.id_empleado == undefined) {
            AppFctry.saveEmpleado({}, empleado).$promise.then(function (res) {
                if (res.length > 0) {
                    $scope.listEmpleado = res;
                    AppService.showMessage("OK! ", "Usuario grabado correctamente.");
                }
            });
        } else {
            AppFctry.updateEmpleado({ id: empleado.id_empleado }, empleado).$promise.then(function (res) {
                if (res.length > 0)
                    AppService.showMessage("OK! ", "Usuario " + empleado.nombres + " Actualizado correctamente.");
            });
        }
    }

    $scope.new = function () {
        $scope.disabled = true;
        $scope.empleado = {};
    }
});
function UploadFile() {
    var fileName = jQuery("#file").get(0).files[0];
    var id_empleado = document.getElementById("id_empleado").value;
    var data = new FormData();
    data.append("fileName", fileName);
    data.append("id_empleado", id_empleado);

    $.ajax({
        type: "POST",
        url: baseurl+'/Empleado/UploadFile',
        contentType: false,
        processData: false,
        data: data,
        success: function (result) {
            alert("Archivo subido correctamente!");
        },
        error: function (error) {
        }
    });
}