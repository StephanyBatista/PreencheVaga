app.controller('CadastroDeCandidatoCtrl', ['$scope', '$routeParams', '$location', '$filter', 'candidatoSvc', 'vagaSvc', 'tecnologiaSvc',
    function CadastroDeCandidatoCtrl($scope, $routeParams, $location, $filter, candidatoSvc, vagaSvc, tecnologiaSvc) {

    vagaSvc.obterPorId($routeParams.id).success(function (result) {

        $scope.vaga = result;
    });
    
    tecnologiaSvc.obterTodos().success(function (result) {
        
        $scope.tecnologias = result;
    });
    
    $scope.salvar = function () {

        if (!$scope.modelo)
            $scope.modelo = {};

        $scope.modelo.tecnologiasQueConhece = [];
        $filter('filter')($scope.tecnologias, {checked: true}).forEach(function (item) {
            
            $scope.modelo.tecnologiasQueConhece.push(item.id);
        });

        candidatoSvc.salvar($scope.modelo)
            .success(function (result) {

                toastr.success("Salvo com sucesso");
                $location.path('/candidato');
            })
            .error(function (message, status, error) {
                
                toastr.error(message);
            });
    }
    
}]);