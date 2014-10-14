var User = require('mongoose').model('User');

module.exports = {
    create: function (user, callback) {
        User.create(user, callback);
    },
    update: function (userId, newUserData, callback) {
        User.update({ _id: userId }, newUserData, callback);
    },
    findOne: function (username, callback) {
        User.findOne({ username: username }, callback);
    }
};