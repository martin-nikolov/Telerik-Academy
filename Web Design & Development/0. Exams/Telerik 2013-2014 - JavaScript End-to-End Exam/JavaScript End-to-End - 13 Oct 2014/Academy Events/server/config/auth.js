var passport = require('passport');

module.exports = {
    login: function (req, res, next) {
        var auth = passport.authenticate('local', function (error, user) {
            if (error) {
                return next(error);
            }

            if (!user) {
                req.session.error = 'The username or password is incorrect.';
                res.redirect('/login');
                // res.send({success: false});
            }

            req.logIn(user, function (error) {
                if (error) {
                    return next(error);
                }

                res.redirect('/');
            })
        });

        auth(req, res, next);
    },
    logout: function (req, res) {
        req.logout();
        res.redirect('/');
    },
    isAuthenticated: function (req, res, next) {
        if (!req.isAuthenticated()) {
            res.redirect('/login');
        }
        else {
            next();
        }
    }
};