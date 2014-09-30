'use strict';

app.directive('footer', function() {
    return {
        restrict: 'A',
        templateUrl: '../../views/directives/footer.html',
        replace: false
    }
});