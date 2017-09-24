app.controller('CadastroDeVagaCtrl', ['$scope', '$routeParams', '$location', 'vagaSvc', 
    function CadastroDeVagaCtrl($scope, $routeParams, $location, vagaSvc) {

    if ($routeParams.id)
        vagaSvc.obterPorId($routeParams.id).success(function (result) {
    
            $scope.modelo = result;
        });
    
    $scope.salvar = function () {

        if (!$scope.modelo)
            $scope.modelo = {};
        
        vagaSvc.salvar($scope.modelo)
            .success(function (result) {

                toastr.success("Salvo com sucesso");
                $location.path('/vaga');
            })
            .error(function (message, status, error) {
                
                toastr.error(message);
            });
    }
    
}]);