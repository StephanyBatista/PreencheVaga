app.config([
    '$routeProvider', function($routeProvider) {
        $routeProvider
        .when("/", {
            templateUrl : "/app/tecnologia/listagem.html"
        })
            
        .when("/tecnologia", {
            templateUrl : "/app/tecnologia/listagem.html"
        })
        .when("/tecnologia/cadastro/", {
            templateUrl : "/app/tecnologia/cadastro.html"
        })
        .when("/tecnologia/cadastro/:id", {
            templateUrl : "/app/tecnologia/cadastro.html"
        })
            
        .when("/vaga", {
            templateUrl : "/app/vaga/listagem.html"
        })
        .when("/vaga/cadastro/", {
            templateUrl : "/app/vaga/cadastro.html"
        })
        .when("/vaga/cadastro/:id", {
            templateUrl : "/app/vaga/cadastro.html"
        })

        .when("/candidato", {
            templateUrl : "/app/candidato/vagas.html"
        })
        .when("/candidato/cadastro/:id", {
            templateUrl : "/app/candidato/cadastro.html"
        })
            
        .otherwise({
            redirectTo: '/'
        });
    }
]);         
