app.controller("LoginCtrl", function ($scope, $location, AppFctry, AppService) {
    $scope.usuario = {};
    $scope.valid = function (usuario) {
        $("#alert").modal("show");
        AppFctry.seLogin({}, usuario).$promise.then(function (res) {
            $("#alert").modal("hide");
            if (res.length > 0) {
                if (res[0].tipo_usuario.toUpperCase() == "ADM")
                    window.location.href = baseurl+"/home/menu";
                else
                    window.location.href = baseurl+"/home/asistencia";
            } else {
                AppService.showMessage("Aviso! ", "Usuario y/o contraseña incorrectos.");
                $scope.usuario = {};
            }
        });
    }
});