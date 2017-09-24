app.controller('ListagemDeVagaCtrl', ['$scope', '$routeParams', 'vagaSvc', function ListagemDeTecnologiaCtrl($scope, $routeParams, vagaSvc) {


    vagaSvc.obterTodos().success(function (data) {
        
        $scope.modelos = data;
    });
    
}]);