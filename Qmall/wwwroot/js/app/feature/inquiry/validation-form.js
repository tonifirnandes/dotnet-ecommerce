var validationFormInquiry = function () {
    var customerEmailDom, customerTelephoneDom, customerInquiryNotesDom,
        customerEmailMsgDom, customerTelephoneMsgDom, cutomerInquiryNotesDom,
        regexEmail, regexPhone;

    var initDom = function () {
        customerEmailDom = $("#customerEmail");
        customerTelephoneDom = $("#customerTelephone");
        customerInquiryNotesDom = $("#customerInquiryNotes");
        customerEmailMsgDom = $("#customerEmailMsg");
        customerTelephoneMsgDom = $("#customerTelephoneMsg");
        customerInquiryNotesMsgDom = $("#customerInquiryNotesMsg");
        regexEmail = /^([a-zA-Z0-9_.+-])+\@(([a-zA-Z0-9-])+\.)+([a-zA-Z0-9]{2,4})+$/;
        regexPhone = /^[0-9]+$/;
    };

    var onKeyup = function () {
        initDom();

        customerEmailDom.keyup(function () {
            if (this.value.length <= 0) {
                customerEmailMsgDom.html("Email can't null");
            } else {
                customerEmailMsgDom.hide();
            }
        });

        customerTelephoneDom.keyup(function () {  
            var requirementConditions = /^[0-9]+$/;
            var phoneCheck = this.value.search(requirementConditions);
            if (phoneCheck != -1) {
                customerTelephoneMsgDom.hide();
            } else {
                customerTelephoneMsgDom.html("Telephone not valid. Please use number only").show();     
            }
        });

        customerInquiryNotesDom.keyup(function () {
            if (this.value.length <= 0) {
                customerInquiryNotesMsgDom.html("Notes can't null").show();
            } else {
                customerInquiryNotesMsgDom.hide();
            }
        });
    };

    var onValidate = function () {
        initDom();
        var valid = true; 
        var emailCheck = regexEmail.test(customerEmailDom.val());
        var phoneCheck = customerTelephoneDom.val().search(regexPhone);

        if (customerEmailDom.val() == "") {
            valid = false;
            customerEmailMsgDom.html("Email can't null").show();
        } else if (!emailCheck) {
            valid = false;
            customerEmailMsgDom.html("Email not valid").show();
        } else {
            valid;
        }

        if (customerTelephoneDom.val() == "") {
            valid = false;
            customerTelephoneMsgDom.html("Telephone can't null").show();
        } else if (phoneCheck == -1) {
            valid = false;
            customerTelephoneMsgDom.html("Telephone not valid. Please use number only").show();
        } else {
            valid;
        }

        if (customerInquiryNotesDom.val() == "") {
            valid = false;
            customerInquiryNotesMsgDom.html("Inquiry Notes can't null").show();
        } else {
            valid;
        }

        return valid;
    };

    return {
        onSubmitValidate: onValidate,
        onKeyUpValidate: onKeyup
    }
}();