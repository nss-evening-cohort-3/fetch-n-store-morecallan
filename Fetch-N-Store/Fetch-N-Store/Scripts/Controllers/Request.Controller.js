app.controller("RequestCtrl", function ($scope, RequestFactory) {

    $scope.response = "";

    $scope.collectData = () => {
        console.log($scope.method)
        console.log($scope.URL)
        RequestFactory.getRequest($scope.method, $scope.URL).then(response => {
            // the response status code, URL, HTTP method used for the original request and response time should be displayed on the page.
            $scope.response = `Status Code: ${response.status}, URL: ${$scope.URL}, HTTP METHOD: ${$scope.method}, RESPONSE TIME: ${response.headers}`
        })
    }

});