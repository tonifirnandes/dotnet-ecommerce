/**
 * This function for get element by id
 * @returns {document.getElementById}
 */
function getElementId(elementNode) {
    return document.getElementById(elementNode);
}

/**
 *
 * @param {any} icon
 * @param {any} title
 * @param {any} message
 * @param {any} type
 */

function notification(icon, title, message, type) {
    $.notify(
        {
            icon: icon,
            title: title,
            message: message
        },
        {
            type: type,
            icon_type: 'image',
            delay: 5000,
            animate: {
                enter: 'animated bounceIn',
                exit: 'animated bounceOut'
            },
            placement: {
                from: 'top',
                align: 'center'
            },
            template: '<div data-notify="container" class="col-xs-11 col-sm-3 alert alert-{0}" role="alert">' +
            '<img data-notify="icon" class="img-circle pull-left">' +
            '<span data-notify="title">{1}</span>' +
            '<span data-notify="message">{2}</span>' +
            '</div>'
        },
    );
}

function GetMessageError() {
    var createElementMsgError = $("<div class='col-xs-12 col-sm-12 section-load-error'>\
                                    <div class='component-msg-error'>\
                                        <i class='fa fa-warning'></i><h3 class='warning-msg-error'>Oops Something Wrong. Please Contact Administrator</h3>\
                                    </div>\
                                </div>");
    return createElementMsgError;
}


function getParameterByName(name, url) {
    if (!url)
        url = window.location.href;

    name = name.replace(/[\[\]]/g, "\\$&");

    var regex = new RegExp("[?&]" + name + "(=([^&#]*)|&|#|$)"),
        results = regex.exec(url);

    if (!results) 
        return null;

    if (!results[2])
        return '';

    return decodeURIComponent(results[2].replace(/\+/g, " "));
}