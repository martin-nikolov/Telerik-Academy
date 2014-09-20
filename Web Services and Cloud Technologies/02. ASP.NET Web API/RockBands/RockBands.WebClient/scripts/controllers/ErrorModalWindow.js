var ErrorModalWindow = (function(){
    function showRestrictedAccessWindow() {
        $('#restricted-access-modal').modal('show');
    }

    return {
        showRestrictedAccessWindow: showRestrictedAccessWindow
    }
}());