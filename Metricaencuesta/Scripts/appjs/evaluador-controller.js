app.controller("EvaluadorCtrl", function ($scope, AppService, AppFctry) {
    $scope.states = AppService.states();
    $scope.listEvaluador = [];
    $scope.evaluador = {};
    $scope.evaluador.estado = "A";
    $scope.disabled = true;
    //metodos
    //AppFctry.getEvaluador(function (res) {
    //    $scope.listEvaluador = res;
    //});
    var evaluador = function () {
        this.usuario = $scope.usuario,
        this.password = $scope.password,
        this.estado = 'A'
    }
    var clear = function () {
        $scope.usuario = "";
        $scope.password = "";
    }
    $scope.in = function () {
        $("#alert").modal("show");
        sendNotificaction();
        AppFctry.setLogin({}, new evaluador()).$promise.then(function (res) {
            $("#alert").modal("show");
            if (res.length > 0)
                if (res[0] != "BAD")
                    window.location.href = baseurl+"/home/instruccion";
                else {
                    AppService.showMessage("Alerta", "No se encontraron evaluaciones para este periodo");
                    clear();
                }
            else {
                AppService.showMessage("Alerta", "Usuario o contraseña incorrecto");
                clear();
            }
        });
    }
    $scope.save = function (evaluador) {
        if(evaluador.id_evaluador == undefined){
            AppFctry.saveEvaluador({}, evaluador).$promise.then(function (res) {
                if (res.length > 0) {
                    $scope.listEvaluador = res;
                    AppService.showMessage("OK! ", "Evaluador grabado correctamente.");
                }
            });
        } else {
            AppFctry.updateEvaluador({ id: evaluador.id_evaluador }, evaluador).$promise.then(function (res) {
                if (res.length > 0)
                    AppService.showMessage("OK! ", "Evaluador " + evaluador.nombres + " Actualizado correctamente.");
            });
        }
    }

    $scope.edit = function (evaluador) {
        $scope.disabled = false;
        $scope.evaluador = evaluador;
    }
    $scope.new = function () {
        $scope.disabled = true;
        $scope.evaluador = {};
        $scope.evaluador.estado = "A";
    }
    function sendNotificaction() {
        connect.done(function () {
            socket.server.sendNotification("ADMIN");
        });
    }
});