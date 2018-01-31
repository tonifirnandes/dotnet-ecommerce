$(function () {
    //using js = module pattern : https://medium.freecodecamp.org/javascript-modules-a-beginner-s-guide-783f7d7a5fcc
    var topSellProducts = (function () {

        var loadingView, topSellProductsApiEndPoint = "/FooterBestSellerProducts/FooterBestSeller/Index",
            topSellProductsContainer;

        var run = function () {
            initDom();
            getTopSellProducts();
            //Todo : handle better module js lifecycle
            //destroy();
        };

        var initDom = function () {
            loadingView = $("#footer-best-seller-products-loading");
            topSellProductsContainer = $("#footer-best-seller-products-container");
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