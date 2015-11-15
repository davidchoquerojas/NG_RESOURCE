app.controller("ClienteCtrl", function ($scope, $location, AppFctry, AppService) {
    $scope.states = AppService.states();
    $scope.cliente = {};
    $scope.listCliente = [];
    $scope.cliente.estado = "A";

    //methods
    AppFctry.getCliente(function (res) {
        $scope.listCliente = res;
    });

    $scope.editcliente = function (cliente) {
        $scope.cliente = cliente;
    }
    $scope.save = function (cliente) {
        if (cliente.id_cliente == undefined) {
            AppFctry.saveCliente({},cliente).$promise.then(function (res) {
                if (res.length > 0) {
                    $scope.listCliente = res;
                    AppService.showMessage("OK! ", "Cliente grabado correctamente.");
                }
            });
        } else {
            AppFctry.updateCliente({ id: cliente.id_cliente }, cliente).$promise.then(function (res) {
                if (res.length > 0)
                    AppService.showMessage("OK! ", "Cliente " + cliente.razon_social+" Actualizado correctamente.");
            });
        }
    }
    //
    $scope.new = function () {
        $scope.cliente = {};
    }

});