$(function () {
    var subscribeNewsletter = function () {
        var subscribeBtn, subscribeEmail, subscribeRequestUrl, emailRegex, defer, filtered,
            subscribeNotifIconMsg, subscribeNotifSuccessStyle, subscribeNotifErrorStyle,
            subscribeNotifType, subscribeNotifEmailSuccessMsg, subscribeNotifEmailExistMsg,
            subscribeNotifEmailNullMsg, subscribeNotifEmailNotValidMsg, subscribeNotifServerErrorMsg;
        var initDom = function () {
            defer = $.Deferred();
            emailRegex = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
            subscribeEmail = $("#subscribe-email");
            subscribeBtn = $("#subscribe-btn");
            subscribeRequestUrl = "/Newsletter/Newsletter/SubscribeNewsletter";
            subscribeNotifIconMsg = "https://raw.githubusercontent.com/irwansaifranto/MyIconsImage/master/customer-service.png";
            subscribeNotifType = "minimalist";
            subscribeNotifSuccessStyle = "<strong>Success : </strong>";
            subscribeNotifErrorStyle = "<strong style='color: red; font-weight: bold'>Info: </strong>";
            subscribeNotifEmailSuccessMsg = "Thanks our team will contact you for new info.";
            subscribeNotifEmailExistMsg = "Email already exist.";
            subscribeNotifEmailNullMsg = "Email empty. PLease input your email.";
            subscribeNotifEmailNotValidMsg = "Email not valid. Please check again.";
            subscribeNotifServerErrorMsg = "Server error. Please contact administrator.";
        };
        var subscribe = function () {
            initDom();
            onSubscribe();
        };
        var onSubscribe = function () {
            subscribeBtn.click(function () {
                if (onValidateEmail(subscribeEmail.val())) {
                    restApi.post(subscribeRequestUrl, {
                        email: subscribeEmail.val()
                    }, onSubscribeSuccess, onSubscribeError);
                } else {
                    notification(subscribeNotifIconMsg, subscribeNotifErrorStyle, subscribeNotifEmailNotValidMsg, subscribeNotifType);
                }             
            });
        };
        var onValidateEmail = function (email) {
            return emailRegex.test(email);
        };
        var onRemoveEmail = function () {
            subscribeEmail.val("");
        };
        var onSubscribeSuccess = function (data) {
            if (data == 1001) {
                onDeferFiltered(notification(subscribeNotifIconMsg, subscribeNotifSuccessStyle, subscribeNotifEmailSuccessMsg, subscribeNotifType));        
            } else if (data == 1000) {
                notification(subscribeNotifIconMsg, subscribeNotifErrorStyle, subscribeNotifEmailExistMsg, subscribeNotifType);
            } else if (data == 403) {
                notification(subscribeNotifIconMsg, subscribeNotifErrorStyle, subscribeNotifEmailNullMsg, subscribeNotifType);
            } else {
                notification(subscribeNotifIconMsg, subscribeNotifErrorStyle, subscribeNotifServerErrorMsg, subscribeNotifType);
            }
        };
        var onDeferFiltered = function (notification) {
            filtered = defer.then(notification);
            defer.resolve();
            filtered.done(onRemoveEmail);
        };
        var onSubscribeError = function (error) {
            notification(subscribeNotifIconMsg, subscribeNotifErrorStyle, subscribeNotifServerErrorMsg, subscribeNotifType);
        };
        return {
            run: subscribe
        };
    }();
    subscribeNewsletter.run();
});