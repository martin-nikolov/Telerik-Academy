module.exports = function (app, data) {
	var posts = require('../app/controllers/posts')(data);
	var users = require('../app/controllers/users')(data);

	app.get('/post', posts.get);
	app.post('/post', posts.createNew);

	app.post('/user', users.register);
	app.post('/auth', users.login);
	app.put('/user', users.logout);
	app.get('/user', users.all);
};