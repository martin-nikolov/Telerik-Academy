var CONSTANTS = {
	TITLE: {
		MIN_LENGTH: 6,
		MAX_LENGTH: 50
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

function filterPostsByUsername(posts, username) {
	username = String(username).toLowerCase();
	var filtered = [];
	for (var i = 0, len = posts.length; i < len; i += 1) {
		var post = posts[i];
		if (post.user.username.toLowerCase() === username) {
			filtered.push(post);
		}
	}
	return filtered;
}

function isPostValid(post) {
	if (!post.title || (typeof post.title !== 'string')) {
		return false;
	}
	if (!post.body || (typeof post.body !== 'string')) {
		return false;
	}
	return true;
}

function filterPostsByPattern(posts, pattern) {
	pattern = String(pattern).toLowerCase();
	var filtered = [];
	for (var i = 0, len = posts.length; i < len; i += 1) {
		var post = posts[i];
		if (post.title.toLowerCase().indexOf(pattern) >= 0) {
			filtered.push(post);
		} else if (post.body.toLowerCase().indexOf(pattern) >= 0) {
			filtered.push(post);
		}
	}
	return filtered;
}

module.exports = function (data) {
	var collectionName = 'posts';

	function getPosts(req, res) {
		var posts = data.get(collectionName);
		var responsePosts = [];
		for (var i = 0, len = posts.length; i < len; i += 1) {
			var post = posts[i];
			var user = data.findById('users', post.userId);
			responsePosts.push({
				id: post.id,
				title: post.title,
				body: post.body,
				postDate: post.postDate,
				user: {
					id: user.id,
					username: user.username
				}
			});
		}

		if (req.query.user) {
			console.log(req.query.user);
			responsePosts = filterPostsByUsername(responsePosts, req.query.user.toLowerCase());
		}
		if (req.query.pattern) {
			responsePosts = filterPostsByPattern(responsePosts, req.query.pattern.toLowerCase());
		}

		res.json(responsePosts);
	}

	function createNewPost(req, res) {
		var sessionKey = req.headers['x-sessionkey'];
		if (!sessionKey) {
			res.status(400)
				.json({
					errCode: 'ERR_INV_AUTH',
					message: 'Requires authentication'
				});
			return;
		}
		var user = findUserBySessionKey(data.get('users'), sessionKey);
		if (!user) {
			res.status(400)
				.json({
					errCode: 'ERR_INV_USR',
					message: 'Invalid user'
				});
			return;

		}
		var post = {
			title: req.body.title,
			body: req.body.body,
			userId: user.id,
			postDate: new Date()
		};

		if (!isPostValid(post)) {
			res.status(400)
				.json({
					errCode: 'ERR_INV_POST',
					message: 'Post is invalid'
				});
			return;
		}

		data.save(collectionName, post);
		res.status(201)
			.json(post);
	}

	return {
		get: getPosts,
		createNew: createNewPost
	};
};