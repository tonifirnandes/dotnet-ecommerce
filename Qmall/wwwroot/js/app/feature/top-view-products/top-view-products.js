$(function () {
    //using js = module pattern : https://medium.freecodecamp.org/javascript-modules-a-beginner-s-guide-783f7d7a5fcc
    var mostViewProducts = (function () {

        var loadingView, mostViewProductsApiEndPoint = "/TopViewProducts/TopViewProducts/Index",
            mostViewProductsContainer;

        var run = function () {
            initDom();
            getMostViewProducts();
            //Todo : handle better module js lifecycle
            //destroy();
        };

        var initDom = function () {
            loadingView = $("#most-view-products-loading");
            mostViewProductsContainer = $("#most-view-products-container");
        };

        var getMostViewProducts = function () {
            showLoading(true);
            restApi.get(mostViewProductsApiEndPoint, null, onGetMostViewProductsSuccess, onGetMostViewProductsError);
        };

        var onGetMostViewProductsSuccess = function (data) {
            showLoading(false);
            mostViewProductsContainer.html(data);
        };

        var onGetMostViewProductsError = function (error) {
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
    mostViewProducts.start();
})