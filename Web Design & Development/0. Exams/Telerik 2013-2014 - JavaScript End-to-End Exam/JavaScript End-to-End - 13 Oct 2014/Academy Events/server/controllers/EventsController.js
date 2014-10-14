var events = require('../data/events'),
    initiatives = require('../data/initiatives');

var NodeCache = require("node-cache");
var myCache = new NodeCache({ stdTTL: 100, checkperiod: 120 });

var CONTROLLER_NAME = 'events';

function isCurrentUserPartOfThisEvent(joinedInUsers, username) {
    for (var i = 0; i < joinedInUsers.length; i++) {
        if (joinedInUsers[i].username === username) {
            return true;
        }
    }

    return false;
}

function hasUserInitiative(user, initiative, sameSeason) {
    for (var i = 0; i < user.initiatives.length; i++) {
        if (user.initiatives[i].name === initiative.name) {
            if (sameSeason && user.initiatives[i].season === initiative.season) {
                return true;
            }
            else if (sameSeason) {
                continue;
            }

            return true;
        }
    }

    return false;
}

module.exports = {
    getAllPassedEventsOnHomePage: function (req, res) {
        var fromCache = myCache.get("events");
        if (fromCache.events) {
            console.log('---------------------------------------------------------');
            console.log('---------------------------------------------------------');
            console.log('FROM CACHE');
            console.log('---------------------------------------------------------');
            console.log('---------------------------------------------------------');
            fromCache = JSON.parse(myCache.get("events").events);
            res.render('index', { events: fromCache });
            return;
        }

        events.getAllPassedEvents(function (events) {
            console.log('---------------------------------------------------------');
            console.log('---------------------------------------------------------');
            console.log('CACHING');
            console.log('---------------------------------------------------------');
            console.log('---------------------------------------------------------');
            myCache.set("events", JSON.stringify(events), 600); // seconds
            res.render('index', { events: events });
        });
    },
    leaveEvent: function (req, res) {
        var currentUserId = req.user._id;
        events.getEventDetails(req.body.id, function (event) {
            var isFound = false;
            for (var i = 0; i < event.joinedInUsers; i++) {
                if (event.joinedInUsers[i].userId === currentUserId) {
                    isFound = true;
                    break;
                }
            }

            if (!isFound) {
                req.session.error = 'Cannot leave event because you are not part of this event!';
                res.send({bad: true});
                return;
            }

            var isPartOfEvent = isCurrentUserPartOfThisEvent(event.joinedInUsers, req.user.username);
            res.render(CONTROLLER_NAME + '/details', { event: event, isCurrentUserPartOfThisEvent: isPartOfEvent });
        });

    },
    joinUserInEvent: function (req, res) {
        var eventId = req.params.id;
        var user = req.user;

        events.getEventDetails(eventId, function (event) {
            if (event.creatorName === user.username) {
                req.session.error = 'You are creator and cannot join in this event!';
                res.redirect('/' + CONTROLLER_NAME + '/details/' + event._id);
                return;
            }

            if (isCurrentUserPartOfThisEvent(event.joinedInUsers, user.username)) {
                req.session.error = 'You are already part of this event!';
                res.redirect('/' + CONTROLLER_NAME + '/details/' + event._id);
                return;
            }

            var eventInitiative = event.initiative;
            if (event.type === 'initiative-based' && !hasUserInitiative(user, eventInitiative)) {
                req.session.error = 'You cannot join in this event because you are not part of "' + eventInitiative.name + '"';
                res.redirect('/' + CONTROLLER_NAME + '/details/' + event._id);
                return;
            }

            if (event.type === 'initiative-and-season-based' && !hasUserInitiative(user, eventInitiative, true)) {
                req.session.error = 'You cannot join in this event because you are not part of "' + eventInitiative.name + ' - Season:' + eventInitiative.season + '"';
                res.redirect('/' + CONTROLLER_NAME + '/details/' + event._id);
                return;
            }

            event.joinedInUsers.push({
                userId: user._id,
                username: user.username
            });

            event.save();
            res.render(CONTROLLER_NAME + '/details', { event: event });
        });
    },
    getAllActiveEvents: function (req, res) {
        events.getAllActiveEvents(function (events) {
            res.render(CONTROLLER_NAME + '/active', { events: events });
        });
    },
    getAllPassedEvents: function (req, res) {
        events.getAllPassedEvents(function (events) {
            res.render(CONTROLLER_NAME + '/past', { events: events });
        });
    },
    getEventDetails: function (req, res) {
        var eventId = req.params.id;

        events.getEventDetails(eventId, function (event) {
            var isPartOfEvent = isCurrentUserPartOfThisEvent(event.joinedInUsers, req.user.username);
            res.render(CONTROLLER_NAME + '/details', { event: event, isCurrentUserPartOfThisEvent: isPartOfEvent });
        });
    },
    getPersonalJoinedEvents: function (req, res) {
        var userId = req.user._id;

        events.getSortedJoinedEventsById(userId, function (events) {
            res.render(CONTROLLER_NAME + '/mine-joined', { events: events });
        });
    },
    getPersonalActiveEvents: function (req, res) {
        var username = req.user.username;

        events.getSortedActiveEventsByUsername(username, function (events) {
            res.render(CONTROLLER_NAME + '/mine-active', { events: events });
        });
    },
    getPersonalPassedEvents: function (req, res) {
        var username = req.user.username;

        events.getSortedPassedEventsByUsername(username, function (events) {
            res.render(CONTROLLER_NAME + '/mine-passed', { events: events });
        });
    },
    getAllPersonalEvents: function (req, res) {
        var username = req.user.username;

        events.getAllEventsByUsername(username, function (events) {
            res.render(CONTROLLER_NAME + '/mine-all', { events: events });
        });
    },
    postEventIndex: function (req, res, next) {
        initiatives.getAll(function (initiatives) {
            res.render(CONTROLLER_NAME + '/create', { categories: events.getCategories(), initiatives: initiatives });
        })
    },
    postEvent: function (req, res, next) {
        var username = req.user.username;
        var phoneNumber = req.user.phoneNumber;

        if (!phoneNumber) {
            req.session.error = 'You cannot create an event because you do not have provided phone number.';
            res.redirect('/events/create');
            return;
        }

        initiatives.getById(req.body.initiative, function (data) {
            var eventModel = {
                title: req.body.title,
                description: req.body.description,
                type: req.body.eventType,
                category: req.body.category,
                eventDate: req.body.eventDate,
                initiative: {
                    name: data.name,
                    season: data.season
                },
                location: {
                    latitude: req.body.latitude,
                    longitude: req.body.longitude
                },
                creatorName: username,
                phoneNumber: phoneNumber
            };

            if (!eventModel.title || !eventModel.description || !eventModel.type || !eventModel.category) {
                req.session.error = 'Invalid event data!';
                res.redirect('/events/create');
                return;
            }

            events.create(eventModel, function (error, event) {
                if (error) {
                    res.status(400);
                    return res.send({reason: error.toString()});
                }

                res.redirect('/' + CONTROLLER_NAME + '/details/' + event._id);
            });
        })
    }
};