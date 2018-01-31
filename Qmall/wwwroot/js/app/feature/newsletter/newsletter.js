$(function () {
    //using js = module pattern : https://medium.freecodecamp.org/javascript-modules-a-beginner-s-guide-783f7d7a5fcc
    var newsletter = (function () {

        var loadingView, newsletterApiEndPoint = "/Newsletter/Newsletter/Index",
            newsletterContainer;

        var run = function () {
            initDom();
            getNewsletter();
            //Todo : handle better module js lifecycle
            //destroy();
        };

        var initDom = function () {
            loadingView = $("#newsletter-loading");
            newsletterContainer = $("#newsletter-container");
        };

        var getNewsletter = function () {
            showLoading(true);
            restApi.get(newsletterApiEndPoint, null, onGetNewsletterSuccess, onGetNewsletterError);
        };

        var onGetNewsletterSuccess = function (data) {
            showLoading(false);
            newsletterContainer.html(data);
        };

        var onGetNewsletterError = function (error) {
            showLoading(false);
            showMsgError(true);
        };

        var showLoading = function (isLoading) {
            if (isLoading) {
                // loading img
            } else {
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
    newsletter.start();
})