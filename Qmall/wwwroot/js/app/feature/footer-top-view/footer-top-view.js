$(function () {
    //using js = module pattern : https://medium.freecodecamp.org/javascript-modules-a-beginner-s-guide-783f7d7a5fcc
    var topViewProducts = (function () {

        var loadingView, topViewProductsApiEndPoint = "/FooterTopViewProducts/FooterTopView/Index",
            topViewProductsContainer;

        var run = function () {
            initDom();
            getTopViewProducts();
            //Todo : handle better module js lifecycle
            //destroy();
        };

        var initDom = function () {
            loadingView = $("#footer-top-view-products-loading");
            topViewProductsContainer = $("#footer-top-view-products-container");
        };

        var getTopViewProducts = function () {
            showLoading(true);
            restApi.get(topViewProductsApiEndPoint, null, onGetTopViewProductsSuccess, onGetTopViewProductsError);
        };

        var onGetTopViewProductsSuccess = function (data) {
            showLoading(false);
            topViewProductsContainer.html(data);
        };

        var onGetTopViewProductsError = function (error) {
            showLoading(false);
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
    topViewProducts.start();
})