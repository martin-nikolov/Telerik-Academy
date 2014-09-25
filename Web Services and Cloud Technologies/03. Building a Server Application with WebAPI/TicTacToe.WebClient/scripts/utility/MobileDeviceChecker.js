var MobileDeviceChecker = (function() {
    function hideFooterIfOnMobileDevice() {
        if(/Android|webOS|iPhone|iPad|iPod|BlackBerry|IEMobile|Opera Mini/i.test(navigator.userAgent)) {
            $('#footer').hide();
        }
    }

    return {
        hideFooterIfOnMobileDevice: hideFooterIfOnMobileDevice
    }
}());