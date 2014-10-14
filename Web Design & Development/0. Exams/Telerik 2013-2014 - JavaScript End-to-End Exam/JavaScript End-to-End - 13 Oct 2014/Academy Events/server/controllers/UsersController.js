var encryption = require('../utilities/encryption'),
    users = require('../data/users'),
    initiatives = require('../data/initiatives');

var CONTROLLER_NAME = 'users';

module.exports = {
    getRegister: function (req, res) {
        initiatives.getAll(function (data) {
            res.render(CONTROLLER_NAME + '/register', { initiatives: data })
        });
    },
    getProfileDetails: function (req, res) {
        var user = req.user;

        res.render(CONTROLLER_NAME + '/profile', { user: user })
    },
    postRegister: function (req, res) {
        var newUserData = req.body;

        if (!(newUserData.username && typeof newUserData.username === 'string' && newUserData.username.length >= 6 && newUserData.username.length <= 20)) {
            req.session.error = 'The username should be between 6 and 20 characters long.';
            res.redirect('/register');
            return;
        }

        if (!(newUserData.password && newUserData.password.length >= 1) && !(newUserData.confirmPassword && newUserData.confirmPassword.length >= 1)) {
            req.session.error = 'The chosen password is invalid!';
            res.redirect('/register');
            return;
        }

        if (newUserData.password != newUserData.confirmPassword) {
            req.session.error = 'Password does not match the confirm password!';
            res.redirect('/register');
            return;
        }

        users.findOne(newUserData.username, function (error, user) {
            if (user) {
                req.session.error = 'Username "' + user.username + '" is already taken!';
                res.redirect('/register');
                return;
            }

            newUserData.salt = encryption.generateSalt();
            newUserData.hashPass = encryption.generateHashedPassword(newUserData.salt, newUserData.password);

            var ids = [];
            if (req.body.initiatives && !Array.isArray(req.body.initiatives)) {
                ids = [req.body.initiatives];
            }
            else if (Array.isArray(req.body.initiatives)) {
                ids = req.body.initiatives;
            }

            initiatives.getByIds(ids, function (data) {
                newUserData.initiatives = [];
                for (var i = 0; i < data.length; i++) {
                    newUserData.initiatives.push({
                        name: data[i].name,
                        season: data[i].season
                    });
                }

                users.create(newUserData, function (error, user) {
                    if (error) {
                        console.log('Failed to register new user: ' + error);
                        return;
                    }

                    req.logIn(user, function (error) {
                        if (error) {
                            res.status(400);
                            return res.send({reason: error.toString()}); // TODO
                        }

                        res.redirect('/');
                    })
                });
            })
        });
    },
    updateUser: function (req, res) {
        var userId = req.user._id;
        var updatedUserData = req.body;

        users.update(userId, updatedUserData, function (data) {
            res.redirect('/profile');
        })
    },
    getLogin: function (req, res) {
        res.render(CONTROLLER_NAME + '/login');
    }
};