app.controller("RequestCtrl", function ($scope, RequestFactory) {

    $scope.responses = [];

    $scope.collectData = () => {

        RequestFactory.getRequest($scope.method, $scope.URL).then(responseObj => {
            let response = {}
            response.statusCode = responseObj.status;
            response.URL = $scope.URL;
            response.method = $scope.method;
            response.responseTime = responseObj.headers;
            // the response status code, URL, HTTP method used for the original request and response time should be displayed on the page.
            $scope.responses.push(response)

            $scope.URL = '';
        })
    }

});