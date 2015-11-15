window.baseurl = "http://localhost:51858";
//window.baseurl = "http://192.168.1.62/encuesta";

try {
    window.socket = $.connection.appNotification;
    window.connect = $.connection.hub.start();
} catch (e) {
    console.log("no necesary");
}
var app = angular.module("app", ["ngResource"]);
app.factory("AppFctry", function ($resource) {
    return $resource(null, { id: "@_id" }, {
        //clientes
        getCliente: { method: "GET", url: baseurl + "/cliente/listAll", isArray: true },
        saveCliente: { method: "POST", url: baseurl + "/cliente/add", isArray: true },
        updateCliente: { method: "POST", params: { id: "@_id" }, url: baseurl + "/cliente/update", isArray: true },
        //evaluador 
        setLogin: { method: "POST", url: baseurl + "/evaluador/login", isArray: true },
        saveEvaluador: { method: "POST", url: baseurl + "/evaluador/save", isArray: true },
        getEvaluador: { method: "GET", url: baseurl + "/evaluador/listall", isArray: true },
        updateEvaluador: { method: "POST", url: baseurl + "/evaluador/update", isArray: true },
        //gpregunta
        getGpregunta: { method: "GET", url: baseurl + "/gpregunta/listall", isArray: true },
        saveGpregunta: { method: "POST", url: baseurl + "/gpregunta/save", isArray: true },
        updateGpregunta: { method: "POST", url: baseurl + "/gpregunta/update", isArray: true },

        //pregunta
        getPregunta: { method: "GET", url: baseurl + "/pregunta/listall", isArray: true },
        savePregunta: { method: "POST", url: baseurl + "/pregunta/save", isArray: true },
        updatePregunta: { method: "POST", url: baseurl + "/pregunta/update", isArray: true },

        //resultado
        getEncuesta: { method: "GET", url: baseurl + "/resultado/listPregunta", isArray: true },
        saveEncuesta: { method: "POST", params: { o: "@_o", e: "@_e" }, url: baseurl + "/resultado/save", isArray: true },
        exportFileEncuesta: { method: "POST", url: baseurl + "/resultado/exportExcelEncuesta", isArray: true },

        //empleado
        getEmpleado: { method: "GET", url: baseurl + "/empleado/listall", isArray: true },
        saveEmpleado: { method: "POST", url: baseurl + "/empleado/add", isArray: true },
        updateEmpleado: { method: "POST", params: { id: "@_id" }, url: baseurl + "/empleado/update", isArray: true },
        updateEmpleadoFoto: { method: "POST", params: { id: "@_id" }, url: baseurl + "/empleado/updateFoto", isArray: true },
        seLogin: { method: "POST", url: baseurl + "/empleado/login", isArray: true },
        setSession: { method: "POST", url: baseurl + "/empleado/setSession", isArray: true },
        getByEvaluador: { method: "GET", url: baseurl + "/empleado/listByEvaluador", isArray: true },

        //asistencia
        getAsistencia: { method: "GET", params: { id: "@_id" }, url: baseurl + "/asistencia/listAll", isArray: true },
        saveAsistencia: { method: "POST", url: baseurl + "/asistencia/add", isArray: true },
        chekMark: { method: "POST", url: baseurl + "/asistencia/chekMark", isArray: true },
        getReport: { method: "POST", url: baseurl + "/asistencia/consult", isArray: true },
        exportFile: { method: "POST", url: baseurl + "/asistencia/exportFile", isArray: true },

        //cliente_empleado
        getClienteEmpleado: { method: "GET", url: baseurl + "/clienteempleado/listAll", isArray: true },
        saveClienteEmpleado: { method: "POST", url: baseurl + "/clienteempleado/save", isArray: true },
        updateClienteEmpleado: { method: "POST", url: baseurl + "/clienteempleado/update", isArray: true },

        //encuesta config
        getEncuestaConfig: { method: "GET", url: baseurl + "/encuestaconfig/listAll", isArray: true },
        saveEncuestaConfig: { method: "POST", url: baseurl + "/encuestaconfig/save", isArray: true },
        updateEncuestaConfig: { method: "POST", url: baseurl + "/encuestaconfig/update", isArray: true }
    });
});