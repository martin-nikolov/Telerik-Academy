var ErrorModalWindow = (function () {
    function showRestrictedAccessWindow(headerMsg, bodyMsg) {
        $('#myModalLabel').html(headerMsg);
        $('#myModalLabeBody').html(bodyMsg);
        $('#restricted-access-modal').modal('show');
    }

    return {
        showRestrictedAccessWindow: showRestrictedAccessWindow
    }
}());