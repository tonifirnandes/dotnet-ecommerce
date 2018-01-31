$(function () {
    //using js = module pattern : https://medium.freecodecamp.org/javascript-modules-a-beginner-s-guide-783f7d7a5fcc
    var topSellProducts = (function () {

        var loadingSell, topSellProductsApiEndPoint = "/TopSellProducts",
            topSellProductsContainer,
            topSellProductsLoadingText = "Loading TopSellProducts";

        var run = function () {
            initDom();
            getTopSellProducts();
            //Todo : handle better module js lifecycle
            //destroy();
        };

        var initDom = function () {
            loadingSell = $("#top-sell-products-loading");
            topSellProductsContainer = $("#top-sell-products-container");
        };

        var getTopSellProducts = function () {
            showLoading(true);
            restApi.get(topSellProductsApiEndPoint, null, onGetTopSellProductsSuccess, onGetTopSellProductsError);
        };

        var onGetTopSellProductsSuccess = function (data) {
            showLoading(false);
            topSellProductsContainer.html(data);
        };

        var onGetTopSellProductsError = function (error) {
            showLoading(false);
            console.log("error:" + error);
        };

        var showLoading = function (isLoading) {
            loadingSell.text(isLoading ? topSellProductsLoadingText : "");
        };

        //Todo : js destroy the cached dome
        var destroy = function () {
            loadingSell = null;
        };

        return {
            start: run
        };
    })();

    //pattern, app/feature start -> init dome / for caching, better performance 
    //-> process data -> destroy() / end to not cache the dom/ data anymore
    topSellProducts.start();
})