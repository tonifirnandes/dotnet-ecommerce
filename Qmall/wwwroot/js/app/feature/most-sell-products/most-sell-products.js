$(function () {
    //using js = module pattern : https://medium.freecodecamp.org/javascript-modules-a-beginner-s-guide-783f7d7a5fcc
    var mostSellProducts = (function () {

        var loadingView, mostSellProductsApiEndPoint = "/MostSellProducts",
            mostSellProductsContainer,
            mostSellProductsLoadingText = "Loading MostSellProducts";

        var run = function () {
            initDom();
            getMostSellProducts();
            //Todo : handle better module js lifecycle
            //destroy();
        };

        var initDom = function () {
            loadingView = $("#most-sell-products-loading");
            mostSellProductsContainer = $("#most-sell-products-container");
        };

        var getMostSellProducts = function () {
            showLoading(true);
            restApi.get(mostSellProductsApiEndPoint, null, onGetMostSellProductsSuccess, onGetMostSellProductsError);
        };

        var onGetMostSellProductsSuccess = function (data) {
            showLoading(false);
            mostSellProductsContainer.html(data);
        };

        var onGetMostSellProductsError = function (error) {
            showLoading(false);
            console.log("error:" + error);
        };

        var showLoading = function (isLoading) {
            loadingView.text(isLoading ? mostSellProductsLoadingText : "");
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
    mostSellProducts.start();
})