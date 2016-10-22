app.factory('RequestFactory', function ($http, $q) {

    getRequest = function (url) {
        return $q(function (resolve, reject) {
            $http({
                method: 'GET',
                url: `${url}`
            }).success(function (data) {
                console.log(data)
                resolve(data);
            });
        });
    }
    return { getRequest: getRequest };
});