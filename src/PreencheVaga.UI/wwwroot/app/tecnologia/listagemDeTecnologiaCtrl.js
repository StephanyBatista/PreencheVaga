app.controller('ListagemDeTecnologiaCtrl', ['$scope', '$routeParams', 'tecnologiaSvc', function ListagemDeTecnologiaCtrl($scope, $routeParams, tecnologiaSvc) {


    tecnologiaSvc.obterTodos().success(function (data) {
        $scope.modelos = data;
    });
    
}]);