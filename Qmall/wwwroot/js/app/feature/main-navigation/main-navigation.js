$(function () {
    //using js = module pattern : https://medium.freecodecamp.org/javascript-modules-a-beginner-s-guide-783f7d7a5fcc
    var mainNavigation = (function () {

        var loadingView, mainNavigationApiEndPoint = "/MainNavigation/MainNavigation/Index",
            mainNavigationContainer;

        var run = function () {
            initDom();
            getMainNavigation();
            //Todo : handle better module js lifecycle
            //destroy();
        };

        var initDom = function () {
            loadingView = $("#main-navigation-loading");
            mainNavigationContainer = $("#main-navigation-container");
        };

        var getMainNavigation = function () {
            showLoading(true);
            restApi.get(mainNavigationApiEndPoint, null, onGetMainNavigationSuccess, onGetMainNavigationError);
        };

        var onGetMainNavigationSuccess = function (data) {
            showLoading(false);
            mainNavigationContainer.html(data);
        };

        var onGetMainNavigationError = function (error) {
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
    mainNavigation.start();
})

