app.factory("candidatoSvc", ['$http', '$q', function ($http, $q) {

    return {
        salvar: salvar
    };

    function salvar(modelo) {
        return $http.post("/api/candidato/", modelo);
    }
}]);
    