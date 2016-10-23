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
    return { getRequest: getRequest };
});