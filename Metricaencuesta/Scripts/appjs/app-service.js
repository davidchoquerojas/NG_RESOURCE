app.service("AppService", function () {
    this.states = function () {
        return [{ code: "A", text: "Activo" }, { code: "I", text: "Inactivo" }];
    },
    this.statesE = function () {
        return [{ code: "C", text: "Creado" }, { code: "F", text: "Finalizado" }];
    },
    this.userType = function () {
        return [{ code: "Col", text: "Colaborador (a)" }, { code: "Adm", text: "Administrador (a)" }];
    },
    this.asisType = function () {
        return [{ code: "Ing", text: "Inicio de Servicio" }, { code: "Sal", text: "Fin de Servicio" }];
    },
    this.getEvaluadorId = function () {
        return document.getElementById("id_evaluador").value;
    },
    this.getUserId = function () {
        return document.getElementById("id_empleado").value;
    },
    this.getEncuestaId = function () {
        return document.getElementById("id_encuesta").value;
    },
    this.showMessage =function(title,message){
        var object = document.createElement("div");
        object.className = "alert alert-success respuesta";
        object.setAttribute("role","alert");
        object.innerHTML = "<p><strong>"+title+" </strong>"+message+"</p>";
        document.body.insertBefore(object,null);
        window.setTimeout(function(){
            object.style.display = "none";
        }, 5000);
    }
});
app.filter('totime', function () {
    return function (jsonDate) {
        var date = new Date(parseInt(jsonDate.substr(6)));
        return date;
    };

});
try {
    var tipo_usuario = document.getElementById("tipo_usuario");
    if (tipo_usuario.value == "Col")
        document.getElementById("home_direct").style.display = "none";
}catch(e){
    console.log("OK");
}
