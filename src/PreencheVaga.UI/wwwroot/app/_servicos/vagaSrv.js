app.factory("vagaSvc", ['$http', '$q', function ($http, $q) {

    return {
        salvar: salvar,
        obterTodos: obterTodos,
        obterPorId: obterPorId
    };

    function salvar(modelo) {
        return $http.post("/api/vaga/", modelo);
    }

    function obterPorId(id) {
        return $http.get("/api/vaga/" + id);
    }

    function obterTodos() {
        return $http.get("/api/vaga/");
    }
}]);
    