app.factory("preencherVagaSvc", ['$http', '$q', function ($http, $q) {

    return {
        processar: processar
    };

    function processar(modelo) {
        return $http.post("/api/preenchervaga/", modelo);
    }
}]);
    