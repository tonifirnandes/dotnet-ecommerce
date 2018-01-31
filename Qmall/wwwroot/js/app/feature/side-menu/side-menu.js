$(function () {
    var sideMenu = (function () {

        var loadingView, sideMenuApiEndPoint = "/SideMenu/SideMenu/Index",
            sideMenuContainer;

        var run = function () {
            initDom();
            getSideMenu();
        };

        var initDom = function () {
            loadingView = $("#side-menu-loading");
            sideMenuContainer = $("#side-menu-container");
        };

        var getSideMenu = function () {
            showLoading(true);
            restApi.get(sideMenuApiEndPoint, null, onGetSideMenuSuccess, onGetSideMenuError);
        };

        var onGetSideMenuSuccess = function (data) {
            showLoading(false);
            sideMenuContainer.html(data);
        };

        var onGetSideMenuError = function (error) {
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

        return {
            start: run
        };
    })();

    sideMenu.start();
})