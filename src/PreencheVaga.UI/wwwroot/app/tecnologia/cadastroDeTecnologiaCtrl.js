app.controller('CadastroDeTecnologiaCtrl', ['$scope', '$routeParams', '$location', 'tecnologiaSvc', 
    function CadastroDeTecnologiaCtrl($scope, $routeParams, $location, tecnologiaSvc) {

    if ($routeParams.id)
        tecnologiaSvc.obterPorId($routeParams.id).success(function (result) {
    
            $scope.modelo = result;
        });
    
    $scope.salvar = function () {

        if (!$scope.modelo)
            $scope.modelo = {};
        
        tecnologiaSvc.salvar($scope.modelo)
            .success(function (result) {

                toastr.success("Salvo com sucesso");
                $location.path('/tecnologia');
            })
            .error(function (message, status, error) {
                
                toastr.error(message);
            });
    }
    
}]);