var CONSTANTS = {
	SESSION_KEY: {
		LENGTH: 50,
		VALID_CHARS: 'qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM'.split('')
	},
	USERNAME: {
		VALID_CHARS: 'qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM1234567890_.'.split(''),
		MIN_LENGTH: 6,
		MAX_LENGTH: 40
	},
	AUTHCODE: {
		LENGTH: 40
	}
};

function findUserBySessionKey(users, sessionKey) {
	for (var i = 0, len = users.length; i < len; i += 1) {
		var user = users[i];
		if (user.sessionKey === sessionKey) {
			return user;
		}
	}
	return null;
}

function findUserByUsername(users, username) {
	for (var i = 0, len = users.length; i < len; i += 1) {
		var user = users[i];
		if (user.username.toLowerCase() === username) {
			return user;
		}
	}
	return null;
}

function generateSessionKey(id) {
	var sessionKey = String(id);
	while (sessionKey.length < CONSTANTS.SESSION_KEY.LENGTH) {
		var index = Math.floor(Math.random() * CONSTANTS.SESSION_KEY.VALID_CHARS.length);
		sessionKey += CONSTANTS.SESSION_KEY.VALID_CHARS[index];
	}
	return sessionKey;
}

function isUsernameValid(username) {
	if (!username ||
		username.length < CONSTANTS.USERNAME.MIN_LENGTH ||
		CONSTANTS.USERNAME.MAX_LENGTH < username.length) {
		return false;
	}
	var validChars = CONSTANTS.USERNAME.VALID_CHARS;
	for (var i = 0, len = username.length; i < len; i += 1) {
		var ch = username[i];
		if (validChars.indexOf(ch) < 0) {
			return false;
		}
	}

	return true;
}

function isAuthCodeValid(authCode) {
	return !!authCode && authCode.length === CONSTANTS.AUTHCODE.LENGTH;
}

function isUserValid(user) {
	return isUsernameValid(user.username) && isAuthCodeValid(user.authCode);
}

module.exports = function (data) {
	var collectionName = 'users';

	function registerUser(req, res) {
		var user = {
			username: req.body.username,
			authCode: req.body.authCode
		};

		if (!isUserValid(user)) {
			res.status(400)
				.json({
					errCode: 'ERR_INV_USR',
					message: 'Invalid user data'
				});
			return;
		}

		var allUsers = data.get(collectionName);

		var dbUser = findUserByUsername(allUsers, user.username.toLowerCase());
		if (dbUser) {
			res.status(400)
				.json({
					errCode: 'ERR_DUP_USR',
					message: 'Username already exists'
				});
			return;
		}

		data.save(collectionName, user);
		res.status(201)
			.json(true);
	}

	function loginUser(req, res) {
		var user = {
			username: req.body.username,
			authCode: req.body.authCode
		};

		//TODO: validate the user and the authCode

		var allUsers = data.get(collectionName);
		var dbUser = findUserByUsername(allUsers, user.username.toLowerCase());

		if (!dbUser || user.authCode !== dbUser.authCode) {
			res.status(400)
				.json({
					errCode: 'ERR_INV_USR',
					message: 'Username or password incorrect'
				});
			return;
		}
		if (!dbUser.sessionKey) {
			dbUser.sessionKey = generateSessionKey(dbUser.id);
			data.update('users', dbUser);
		}

		res.json({
			username: dbUser.username,
			sessionKey: dbUser.sessionKey
		});
	}


	function logoutUser(req, res) {
		var sessionKey = req.headers['x-sessionkey'];
		if (!sessionKey) {
			res.status(400)
				.json({
					errCode: 'ERR_INV_AUTH',
					message: 'Requires authentication'
				});
			return;
		}
		var dbUser = findUserBySessionKey(data.get('users'), sessionKey);
		if (!dbUser) {
			res.status(400)
				.json({
					errCode: 'ERR_INV_USR',
					message: 'Invalid user'
				});
			return;

		}

		dbUser.sessionKey = undefined;
		data.update('users', dbUser);

		res.json(true);
	}

	//for test purposes, must be deleted before the exam
	function getAll(req, res) {
		res.json({
			users: data.get('users')
		});
	}

	return {
		register: registerUser,
		login: loginUser,
		logout: logoutUser,

		//for test purposes, must be deleted before the exam
		all: getAll
	};
};