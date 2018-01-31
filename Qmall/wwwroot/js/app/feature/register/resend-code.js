var loading = $('<i class="fa fa-refresh fa-spin"></i>');

$("#resend-code").click(function (e) {
    $(this).append(loading);

    $.get("/Register/Form/ResendCode", { verifiedCode: $("#verifiedCode").val() }, function (data, status, xhr) {
        removeValidationCode();
        removeLoading(data.messageError);
    })
})

function removeLoading(msgErr) {
    setTimeout(function () {
        $(loading).remove();
        limitCodeMessage(msgErr);
    }, 2500);   
}

function limitCodeMessage(msgErr) {
    if (msgErr !== null) 
        $(".limit-code-info").html(msgErr);
    else
        $("#msg-info").html("The New Code has been sent to your phone. Please check your phone.")
}

function removeValidationCode() {
    $("#msg-err-code").html("");
}


