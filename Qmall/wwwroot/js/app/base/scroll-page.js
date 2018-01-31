$(function () {
    var scrollPage = function () {
        var header;
        var scroll = function () {
            initDom();
            onScroll();
        };
        var initDom = function () {
            header = $("header");
        };
        var onScroll = function () {
            $(window).scroll(function () {
                if ($(this).scrollTop() > 50) {
                    header.addClass('fix-header');
                    header.css("background-color", "white");
                } else {
                    header.removeClass('fix-header');
                }
            });
        };
        return {
            run: scroll
        };
    }();
    scrollPage.run();
});