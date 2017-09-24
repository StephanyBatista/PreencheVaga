app.factory("tecnologiaSvc", ['$http', '$q', function ($http, $q) {

    return {
        salvar: salvar,
        obterTodos: obterTodos,
        obterPorId: obterPorId
    };

    function salvar(modelo) {
        return $http.post("/api/tecnologia/", modelo);
    }

    function obterPorId(id) {
        return $http.get("/api/tecnologia/" + id);
    }

    function obterTodos() {
        return $http.get("/api/tecnologia/");
    }
}]);
    