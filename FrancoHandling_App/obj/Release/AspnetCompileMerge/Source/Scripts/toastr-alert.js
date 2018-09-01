
function Alert(AlertType, Title, Message) {
    var shortCutFunction = AlertType;
    var msg = Message;
    var title = Title;
    var toastIndex = 0;
    var addClear = false;

    toastr.options = {
        closeButton: true,
        debug: false,
        newestOnTop: false,
        progressBar: false,
        rtl: true,
        //positionClass: 'toast-top-full-width',
        positionClass: 'toast-bottom-right',
        preventDuplicates: false,
        onclick: null,
    };
                    
    toastr.options.showDuration = parseInt('300');                
    toastr.options.hideDuration = parseInt('1000');
    toastr.options.timeOut = addClear ? 0 : parseInt('10000');
    toastr.options.extendedTimeOut = addClear ? 0 : parseInt('1000');
    toastr.options.showEasing = 'swing';
    toastr.options.hideEasing = 'linear';
    toastr.options.showMethod = 'fadeIn';
    toastr.options.hideMethod = 'fadeOut';
    toastr.options.tapToDismiss = false;

    if (addClear) {
        msg = getMessageWithClearButton(msg);
        toastr.options.tapToDismiss = false;
    }

    if (!msg) {
        msg = 'No Message Found';
    }

    var $toast = toastr[shortCutFunction](msg, title); // Wire up an event handler to a button in the toast, if it exists
    $toastlast = $toast;
}

