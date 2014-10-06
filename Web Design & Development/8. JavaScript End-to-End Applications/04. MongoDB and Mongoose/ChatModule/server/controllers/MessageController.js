var Message = require('mongoose').model('Message');

module.exports = {
    sendMessage: function (request) {
        var messageData = {
            from: request.from,
            to: request.to,
            text: request.text
        };

        Message.create(messageData, function (error) {
            if (error) {
                console.log('Failed to register new user: ' + error);
                return;
            }
        });
    },
    getMessagesBetweenUsers: function (request, callback) {
        Message.find().or([{from: request.with, to: request.and}, {from: request.and, to: request.with}]).exec(function (error, messages) {
            if (error) {
                console.log('Messages could not be loaded: ' + error);
                return;
            }

            callback(messages);
        })
    }
};