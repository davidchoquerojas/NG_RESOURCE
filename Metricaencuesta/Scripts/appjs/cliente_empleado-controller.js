app.controller("ClienteEmpleadoCtrl", function ($scope, $location, AppFctry, AppService) {
    $scope.states = AppService.states();
    $scope.cliemp = {};
    $scope.listCliente = [];
    $scope.listEmpleado = [];
    $scope.listEvaluador = [];
    $scope.listCliEmp = [];

    //methods
    AppFctry.getCliente(function (res) {
        $scope.listCliente = res;
    });

    AppFctry.getEmpleado({id:0},function (res) {
        $scope.listEmpleado = res;
    });

    AppFctry.getEvaluador(function (res) {
        $scope.listEvaluador = res;
    });

    AppFctry.getClienteEmpleado(function (res) {
        $scope.listCliEmp = res;
    });

    $scope.editcliente = function (cliemp) {
        $scope.cliemp = cliemp;
    }
    $scope.save = function (cliemp) {
        if (cliemp.id_cliemp == undefined) {
            AppFctry.saveClienteEmpleado({}, cliemp).$promise.then(function (res) {
                if (res.length > 0) {
                    $scope.listCliEmp = res;
                    AppService.showMessage("OK! ", "cliente empleado grabado correctamente.");
                }
            });
        } else {
            AppFctry.updateClienteEmpleado({ id: cliemp.id_cliemp }, cliemp).$promise.then(function (res) {
                if (res.length > 0)
                    AppService.showMessage("OK! ", "cliente actualizado correctamente.");
            });
        }
    }
    //
    $scope.new = function () {
        $scope.cliente = {};
    }

});