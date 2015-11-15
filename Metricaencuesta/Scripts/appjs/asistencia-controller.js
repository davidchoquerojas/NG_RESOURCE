var latitude,longitude;
app.controller("AsistenciaCtrl", function ($scope, $location, $timeout, AppFctry, AppService) {
    $scope.asisType = AppService.asisType();
    $scope.dateNow = "";
    $scope.timeNow = "";
    $scope.listAsistencia = [];

    navigator.geolocation.getCurrentPosition(function(position){
        latitude = position.coords.latitude;
        longitude = position.coords.longitude;
    });
    AppFctry.getAsistencia({ id: AppService.getUserId()}, function (res) {
        $scope.listAsistencia = res;
    });
    var UpdateDate = function () {
        $scope.dateNow = new Date();
        $scope.timeNow = new Date();
        $timeout( UpdateDate, 1000);
    }
    var asistencia = function () {
        this.id_empleado = AppService.getUserId(),
        this.tipo_asistencia = $scope.tipo_asistencia,
        this.ip_conexion = "localhost"
        this.latitud = latitude.toString(),
        this.longitud = longitude.toString(),
        this.estado = "A"
    };
    $scope.save = function () {
        AppFctry.saveAsistencia({}, new asistencia()).$promise.then(function (res) {
            if(res.length > 0){
                AppService.showMessage("OK! ", "Asistencia marcarda con exito.");
                $scope.listAsistencia = res;
                $scope.tipo_asistencia = undefined;
            }
        });
    }

    $scope.chekMark = function () {
        AppFctry.chekMark({}, new asistencia).$promise.then(function (res) {
            if (res.length > 0) {
                AppService.showMessage("Aviso ", "La Asistencia para hoy dia, ya fue marcada.");
                $scope.tipo_asistencia = undefined;
            }
        });
    }

    //load
    UpdateDate();
});