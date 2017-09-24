app.controller('ProcessarCandidatosCtrl', ['$scope', '$routeParams', '$location', '$filter', 'vagaSvc', 'tecnologiaSvc', 'preencherVagaSvc',
    function ProcessarCandidatosCtrl($scope, $routeParams, $location, $filter, vagaSvc, tecnologiaSvc, preencherVagaSvc) {

    $scope.candidatos = null;
    vagaSvc.obterPorId($routeParams.id).success(function (result) {

        $scope.vaga = result;
    });
    
    tecnologiaSvc.obterTodos().success(function (result) {
        
        $scope.tecnologias = result;
    });
    
    $scope.processar = function () {

        
        $scope.modelo = {};
        $scope.modelo.VagaId = $routeParams.id;

        $scope.modelo.PesosDasTecnologias = [];
        $filter('filter')($scope.tecnologias).forEach(function (item) {
            
            if (item.peso)
                $scope.modelo.PesosDasTecnologias.push({TecnologiaId: item.id, Peso: parseInt(item.peso)});
        });

        preencherVagaSvc.processar($scope.modelo)
            .success(function (result) {

                if (result.length == 0)
                {
                    $scope.candidatos = null;
                    toastr.success("Processado, mas não foi encontrado ninguém");
                }    
                else
                {
                    toastr.success("Processado, veja a lista abaixo");
                    $scope.candidatos = result;
                }    
            })
            .error(function (message, status, error) {
                
                toastr.error(message);
            });
    }
    
}]);