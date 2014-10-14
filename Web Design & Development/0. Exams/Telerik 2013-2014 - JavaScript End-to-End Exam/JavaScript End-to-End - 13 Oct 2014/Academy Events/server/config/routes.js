var auth = require('./auth'),
    controllers = require('../controllers');

module.exports = function (app) {
    app.get('', controllers.events.getAllPassedEventsOnHomePage);

    app.get('/register', controllers.users.getRegister);
    app.post('/register', controllers.users.postRegister);

    app.get('/login', controllers.users.getLogin);
    app.post('/login', auth.login);
    app.get('/logout', auth.isAuthenticated, auth.logout);

    // Event areas
    app.get('/events/create', auth.isAuthenticated, controllers.events.postEventIndex);
    app.post('/events/create', auth.isAuthenticated, controllers.events.postEvent);
    app.put('/events/', auth.isAuthenticated, controllers.events.leaveEvent);

    app.get('/events/active', auth.isAuthenticated, controllers.events.getAllActiveEvents);
    app.get('/events/past', auth.isAuthenticated, controllers.events.getAllPassedEvents);
    app.get('/events/details/:id', auth.isAuthenticated, controllers.events.getEventDetails);
    app.post('/events/details/:id', auth.isAuthenticated, controllers.events.joinUserInEvent);


    app.get('/events/mine-passed', auth.isAuthenticated, controllers.events.getPersonalPassedEvents);
    app.get('/events/mine-active', auth.isAuthenticated, controllers.events.getPersonalActiveEvents);
    app.get('/events/mine-all', auth.isAuthenticated, controllers.events.getAllPersonalEvents);
    app.get('/events/mine-joined', auth.isAuthenticated, controllers.events.getPersonalJoinedEvents);

    app.get('/profile', auth.isAuthenticated, controllers.users.getProfileDetails);
    app.post('/profile', auth.isAuthenticated, controllers.users.updateUser);

    app.get('/', function (req, res) {
        res.render('index');
    });

    app.get('*', function (req, res) {
        res.render('index');
    });
};