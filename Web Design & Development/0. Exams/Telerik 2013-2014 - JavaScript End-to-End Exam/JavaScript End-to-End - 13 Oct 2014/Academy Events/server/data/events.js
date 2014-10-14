var Event = require('mongoose').model('Event');

module.exports = {
    create: function (event, callback) {
        Event.create(event, callback);
    },
    getAllActiveEvents: function (callback) {
        Event.find({ eventDate: { $gte: Date.now() }}, null, { sort: { eventDate: -1 } }, function (error, events) {
            callback(events);
        })
    },
    getAllPassedEvents: function (callback) {
        Event.find({ eventDate: { $lt: Date.now() }}, null, { sort: { eventDate: -1 } }, function (error, events) {
            callback(events);
        })
    },
    getCategories: function () {
        return Event.schema.path('category').enumValues;
    },
    getEventDetails: function (eventId, callback) {
        Event.findOne({ _id: eventId }, function (error, event) {
            callback(event);
        })
    },
    getAllEventsByUsername: function (username, callback) {
        Event.find({ creatorName: username }, null, { sort: { eventDate: -1 } }, function (error, events) {
            callback(events);
        })
    },
    getSortedJoinedEventsById: function (userId, callback) {
        Event.find({}, function (error, events) {
            var matched = [];

            for (var i = 0; i < events.length; i++) {
                for (var j = 0; j < events[i].joinedInUsers.length; j++) {
                    if (events[i].joinedInUsers[j].userId === userId) {
                        matched.push(events[i]);
                        break;
                    }
                }
            }

            callback(matched);
        })
    },
    getSortedPassedEventsByUsername: function (username, callback) {
        Event.find({ creatorName: username, eventDate: { $lt: Date.now() }}, null, { sort: { eventDate: -1 } }, function (error, events) {
            callback(events);
        })
    },
    getSortedActiveEventsByUsername: function (username, callback) {
        Event.find({ creatorName: username, eventDate: { $gte: Date.now() }}, null, { sort: { eventDate: -1 } }, function (error, events) {
            callback(events);
        })
    }
};