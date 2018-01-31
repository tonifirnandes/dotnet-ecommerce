$(function () {
    //using js = module pattern : https://medium.freecodecamp.org/javascript-modules-a-beginner-s-guide-783f7d7a5fcc
    var mostViewProducts = (function () {

        var loadingView, mostViewProductsApiEndPoint = "/MostViewProducts",
            mostViewProductsContainer,
            mostViewProductsLoadingText = "Loading MostViewProducts";

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
            console.log("error:" + error);
        };

        var showLoading = function (isLoading) {
            loadingView.text(isLoading ? mostViewProductsLoadingText : "");
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