'use strict';

rockBandsApp.directive('footer', function() {
    return {
        restrict: 'A',
        templateUrl: 'templates/directives/footer.html',
        replace: false
    }
});