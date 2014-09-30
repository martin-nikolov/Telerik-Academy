'use strict';

// manages the storage of the username and user access token - uses angular cookie store module
app.factory('identity', function($cookieStore) {
    var storageUsernameKey = 'tictactoeUserName';
    var storageTokenKey = 'tictactoeUserToken';

    return {
        getUsername: function() {
            return $cookieStore.get(storageUsernameKey);
        },
        getToken : function() {
            return $cookieStore.get(storageTokenKey);
        },
        loginUser: function(username, token){
            $cookieStore.put(storageUsernameKey, username);
            $cookieStore.put(storageTokenKey, token);
        },
        logoutUser: function() {
            $cookieStore.remove(storageTokenKey);
            $cookieStore.remove(storageUsernameKey);
        },
        isAuthenticated : function() {
            return $cookieStore.get(storageTokenKey) != undefined;
        }
    }
});