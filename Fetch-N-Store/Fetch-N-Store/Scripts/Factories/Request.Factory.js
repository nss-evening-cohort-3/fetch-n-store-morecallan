app.factory('RequestFactory', function ($http, $q) {

    getRequest = function (method, url) {
        return $q(function (resolve, reject) {
            $http({
                method: `${method}`,
                url: `${url}`
            }).success(function (data, status, headers, config) {
                resolve({response: data, status: status, headers: new Date()});
            });
        });
    }

    StoreResponse = function (response) {
        console.log(response)
        return $q(function (resolve, reject) {
            $http({
                method:  "POST",
                url: "/api/Response",
                data: response
            }).success(function (data, status, headers, config) {
                console.log("made it")
                resolve(data);
            });
        })
    }

    DisplayStoredResponses = function () {
        return $q(function (resolve, reject) {
            $http({
                method: "GET",
                url: "/api/Response",
            }).success(function (data, status, headers, config) {
                resolve(data);
            });
        })
    }

        return { getRequest: getRequest,  StoreResponse: StoreResponse, DisplayStoredResponses: DisplayStoredResponses};
});