//to be used globally
var restApi = (function () {

    var requestParamJsonContentType;
    var responseJsonType;

    var ajaxGetRestApi = function (apiEndPoint, requestParam, onSuccess, onError) {

        $.ajax({
            beforeSend: ajaxRestApiCustomSetup,
            type: "GET",
            url: apiEndPoint,
            data: requestParam,
            contentType: requestParamJsonContentType,
            dataType: responseJsonType,
            success: onSuccess,
            error: onError
        });
    };

    var ajaxRestApiCustomSetup = function (xhr) {
        console.log("Rest api before send");
        //example - setup request header - xhr.setRequestHeader("Authorization", "Foooo");
    };

    var setContentType = function (contentTypeString) {
        requestParamJsonContentType = contentTypeString;
    };

    var setResponseType = function (responseTypeString) {
        responseJsonType = responseTypeString;
    };

    return {
        get: ajaxGetRestApi,
        setup: ajaxRestApiCustomSetup,
        setContentType: setContentType,
        setResponseType: setResponseType
    };
})();