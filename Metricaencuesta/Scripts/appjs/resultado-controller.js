//P = padre
//H = hijo
app.controller("ResultadoCtrl", function ($scope, AppService, AppFctry) {
    var id_evaluador = AppService.getEvaluadorId();
    $scope.screen = 1;
    $scope.listEncuesta = [];
    $scope.listColaborador = [];
    var encuestaMarcador = [];
    var configEncuesta = function (encuesta) {
        var index = 0;
        for (var i = 0; i < encuesta.length;i++) {
            var entity = {
                descripcion: encuesta[i].descripcion,
                id_gpregunta: encuesta[i].id_gpregunta,
                id_pregunta: encuesta[i].id_pregunta,
                puntaje:null,
                tipo: "P",
                index: -1
            }
            ++index;
            $scope.listEncuesta.push(entity);
            for (var c = 0; c < encuesta[i].subencuesta.length;c++) {
                var entitysub = {
                    descripcion: encuesta[i].subencuesta[c].descripcion,
                    id_gpregunta: encuesta[i].subencuesta[c].id_gpregunta,
                    id_pregunta: encuesta[i].subencuesta[c].id_pregunta,
                    puntaje:null,
                    tipo: "H",
                    index: index
                }
                $scope.listEncuesta.push(entitysub);
                index++;
            }
        }
    };
    AppFctry.getEncuesta(function (res) {
        configEncuesta(res);
        encuestaMarcador = $scope.listEncuesta;
    });

    $scope.chekMe = function (value,index) {
        encuestaMarcador[index].puntaje = value;
    }

    AppFctry.getByEvaluador({ id: id_evaluador }, function (res) {
        $scope.listColaborador = res;
    });
    var clear = function () {
        $scope.id_empleado = undefined;
        $scope.comentario = "";
    }
    //save resultado
    var resultado = function (i) {
        this.id_encuesta = AppService.getEncuestaId();
        this.id_evaluador = id_evaluador,
        this.id_empleado = $scope.id_empleado,
        this.id_pregunta = encuestaMarcador[i].id_pregunta,
        this.puntaje = encuestaMarcador[i].puntaje,
        this.comentario = $scope.comentario
    }

    var encuesta = function (i) {
        this.id_gpregunta = encuestaMarcador[i].id_gpregunta,
        this.id_pregunta = encuestaMarcador[i].id_pregunta,
        this.descripcion = encuestaMarcador[i].descripcion,
        this.puntaje = encuestaMarcador[i].puntaje
    }

    $scope.save = function () {
        var formValidator = true;
        var saveEncuesta = [];
        var saveResultado = [];
        for (var i = 0; i < encuestaMarcador.length; i++) {
            if (encuestaMarcador[i].tipo == "P")
                saveEncuesta.push(new encuesta(i));
            if (encuestaMarcador[i].tipo == "H" && encuestaMarcador[i].puntaje > 0) {
                saveResultado.push(new resultado(i));
                saveEncuesta.push(new encuesta(i));
            } else {
                if (encuestaMarcador[i].tipo != "P") {
                    formValidator = false;
                    alert("Por favor, revise y marque todas las casillas");
                    break;
                }
            }
           
        }
        if (formValidator == true) {
            $("#alert").modal("show");
            AppFctry.saveEncuesta({ o: saveResultado, e: saveEncuesta }).$promise.then(function (res) {
                if (res[0] == "OK") {
                    $("#alert").modal("hide");
                    AppService.showMessage("OK! ", "Encuesta realizado correctamente, para el colaborador " + $scope.id_empleado);
                    clear();
                }
            });
        }
    }
    $scope.new = function () {
        clear();
    }
});