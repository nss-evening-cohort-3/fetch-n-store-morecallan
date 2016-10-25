app.controller("RequestCtrl", function ($scope, RequestFactory) {

    $scope.responses = [];

    $scope.collectData = () => {

        RequestFactory.getRequest($scope.method, $scope.URL).then(responseObj => {
            let response = {}
            response.StatusCode = responseObj.status;
            response.URL = $scope.URL;
            response.Method = $scope.method;
            response.ResponseTime = responseObj.headers;
            // the response status code, URL, HTTP method used for the original request and response time should be displayed on the page.
            $scope.responses.push(response)

            $scope.URL = '';
        })
    }

    $scope.storeData = (response) => {
        RequestFactory.StoreResponse(response).then(() => {
            RequestFactory.DisplayStoredResponses().then((storedResponses) => {
                $scope.storedResponses = storedResponses;
            })
        })
    }


});