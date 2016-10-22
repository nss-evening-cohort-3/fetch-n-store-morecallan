app.factory('RequestFactory', function ($http, $q) {

    getRequest = function (method, url) {
        return $q(function (resolve, reject) {
            $http({
                method: `${method}`,
                url: `${url}`
            }).success(function (response) {
                console.log(response)
                resolve(response);
            });
        });
    }
    return { getRequest: getRequest };
});