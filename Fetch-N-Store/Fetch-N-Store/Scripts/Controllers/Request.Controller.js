app.controller("RequestCtrl", function ($scope, RequestFactory) {

    $scope.response = "";

    $scope.collectData = () => {
        console.log($scope.method.value)
        console.log($scope.URL)
        RequestFactory.getRequest($scope.method.value, $scope.URL).then(response => {
            // the response status code, URL, HTTP method used for the original request and response time should be displayed on the page.
            console.log(response)
            $scope.response = `Status Code: ${resopnse.status}, URL: ${$scope.URL}, HTTP METHOD: ${response.headers()}`
        })
    }

});