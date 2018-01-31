$(function () {
    //using js = module pattern : https://medium.freecodecamp.org/javascript-modules-a-beginner-s-guide-783f7d7a5fcc
    var topNavigation = (function () {

        var loadingView, topNavigationApiEndPoint = "/TopNavigation/TopNavigation/Index",
            topNavigationContainer;

        var run = function () {
            initDom();
            getTopNavigation();
            //Todo : handle better module js lifecycle
            //destroy();
        };

        var initDom = function () {
            loadingView = $("#top-navigation-loading");
            topNavigationContainer = $("#top-navigation-container");
        };

        var getTopNavigation = function () {
            showLoading(true);
            restApi.get(topNavigationApiEndPoint, null, onGetTopNavigationSuccess, onGetTopNavigationError);
        };

        var onGetTopNavigationSuccess = function (data) {
            showLoading(false);
            topNavigationContainer.html(data);
        };

        var onGetTopNavigationError = function (error) {
            showLoading(false);
            showMsgError(true);
        };

        var showLoading = function (isLoading) {
            if (isLoading) {
            }
            else {
                loadingView.html("");
            }             
        };

        var showMsgError = function (isError) {
            if (isError) {
                loadingView.html("<p class='loadingMsgErr'>Something wrong. Please Contact Administrator</p>")
            } else {
                loading.html("");
            }
        };

        //Todo : js destroy the cached dome
        var destroy = function () {
            loadingView = null;
        };

        return {
            start: run
        };
    })();

    //pattern, app/feature start -> init dome / for caching, better performance 
    //-> process data -> destroy() / end to not cache the dom/ data anymore
    topNavigation.start();
})