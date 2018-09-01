$(document).ready(function() {
    $(window).resize(adjustNavMenu);
    $(window).scroll(function() {
        toogleFixedTopPanel();
        toogleBackToTopButton();
    });
    $("#btnBackToTop").click(function(event) {
        event.preventDefault();
        $("html, body").animate({ scrollTop: 0 }, '500');
        return false;
    });
});

function toogleFixedTopPanel(){
    if($(document).scrollTop() > 100 && !TopPanel.IsExpandable()) {
        $('header').addClass('shrink');
        $('body').css('padding-top', $('header').outerHeight());
    } else {
        $('header').removeClass('shrink');
        $('body').css('padding-top', 0);
    }
}
function toogleBackToTopButton(){
    var offset = 200;
    if($(this).scrollTop() > offset)
        $(".btnBackToTop").removeClass("hidden");
    else
        $(".btnBackToTop").addClass("hidden");
}
function adjustNavMenu() {
    try {
        var orientation = TopPanel.IsExpandable() ? 'Vertical' : 'Horizontal';
        if (orientation !== NavMenu.GetOrientation())
            NavMenu.SetOrientation(orientation);

    }
    catch (ex)
    { }
}

function ShowModalPopupMsg(msg) {
    if (/success/i.test(msg)) {
        lblMsg.GetMainElement().style.color = 'green';
    }
    else if (/warning/i.test(msg)) {
        lblMsg.GetMainElement().style.color = 'orange';
    }
    else{
        lblMsg.GetMainElement().style.color = 'red';
    }

    lblMsg.SetText(msg);
    popupMsg.Show();
}

function GvEndCallbackShowModalPopupMsg(s, e) {
    if (s.cpRes != null && s.cpRes != "") {
        if (/success/i.test(s.cpRes) || /warning/i.test(s.cpRes))
            ShowModalPopupMsg(s.cpRes);
        else
            Alert("error", "", s.cpRes);

        s.cpRes = null;
    }
}

function GvEndCallbackShowPopupMsg(s, e) {
    if (s.cpRes != null && s.cpRes != "") {
        if (/success/i.test(s.cpRes)) {
            Alert("success", "", s.cpRes);
        }
        else if (/warning/i.test(s.cpRes)) {
            Alert("warning", "", s.cpRes);
        }
        else if (/error/i.test(s.cpRes)) {
            Alert("error", "", s.cpRes);
        }
        else{
            Alert("info", "", s.cpRes);
        }

        s.cpRes = null;
    }
}

function InputDigitOnly (s,e)
{
    var theEvent = e.htmlEvent || window.event;
    var key = theEvent.keyCode || theEvent.which;
    key = String.fromCharCode(key);
    var regex = /[0-9\b\t]/;

    if(!regex.test(key))
    {
        theEvent.returnValue = false;
        if(theEvent.preventDefault) 
            theEvent.preventDefault();
    }
}
