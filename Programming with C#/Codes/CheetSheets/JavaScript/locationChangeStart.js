app.run(function($rootScope, $location, identity) {
    $rootScope.$on('$locationChangeStart', function(ev, current, previous, rejection) {
        if (!identity.isAuthenticated()) {
            $location.path('/register');
        }
    });
});