(function () {
    // Const
    var netscapeBrowserName = "Netscape";

    // Variables
    var browserName = navigator.appName
    var addScroll = false;
    var theLayer;
    var pX = 0;
    var pY = 0;

    if ((navigator.userAgent.indexOf('MSIE 5') > 0) || (navigator.userAgent.indexOf('MSIE 6')) > 0) {
        addScroll = true;
    }

    if (browserName == netscapeBrowserName) {
        document.captureEvents(Event.MOUSEMOVE)
    }

    document.onmousemove = mouseMove;

    function mouseMove(eventObj) {
        if (browserName == netscapeBrowserName) {
            pX = eventObj.pageX - 5;
            pY = eventObj.pageY;
        }
        else {
            pX = eventObj.x - 5;
            pY = eventObj.y;
        }

        if (browserName == netscapeBrowserName) {
            if (document.layers['ToolTip'].visibility == 'show') {
                PopToolTip();
            }
        }
        else if (document.all['ToolTip'].style.visibility == 'visible') {
            PopToolTip();
        }
    }

    function PopToolTip() {
        if (browserName == netscapeBrowserName) {
            theLayer = eval('document.layers[\'ToolTip\']');

            if ((pX + 120) > window.innerWidth) {
                pX = window.innerWidth - 150;
            }

            theLayer.left = pX + 10;
            theLayer.top = pY + 15;
            theLayer.visibility = 'show';
        }
        else {
            theLayer = eval('document.all[\'ToolTip\']');

            if (theLayer) {
                pX = eventObj.x - 5;
                pY = eventObj.y;

                if (addScroll) {
                    pX = pX + document.body.scrollLeft;
                    pY = pY + document.body.scrollTop;
                }

                if ((pX + 120) > document.body.clientWidth) {
                    pX = pX - 150;
                }

                theLayer.style.pixelLeft = pX + 10;
                theLayer.style.pixelTop = pY + 15;
                theLayer.style.visibility = 'visible';
            }
        }
    }

    function HideToolTip() {
        args = HideToolTip.arguments;

        if (browserName === netscapeBrowserName) {
            document.layers.ToolTip.visibility = "hide";
        }
        else {
            document.all.ToolTip.style.visibility = "hidden";
        }
    }

    function HideMenu(menuName) {
        if (browserName == netscapeBrowserName) {
            document.layers[menuName].visibility = 'hide';
        }
        else {
            document.all[menuName].style.visibility = 'hidden';
        }
    }

    function ShowMenu(menuName) {
        if (browserName == netscapeBrowserName) {
            theLayer = eval('document.layers[\'' + menuName + '\']');
            theLayer.visibility = 'show';
        }
        else {
            theLayer = eval('document.all[\'' + menuName + '\']');
            theLayer.style.visibility = 'visible';
        }
    }
})();