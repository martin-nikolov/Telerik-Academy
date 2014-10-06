var env = process.env.NODE_ENV || 'development',
    config = require('./server/config/config')[env],
    chatSystem = require('./server/controllers/ChatSystem');

chatSystem.init(config);
chatSystem.registerUser({ username: 'DonchoMinkov', password: '123456q' });
chatSystem.registerUser({ username: 'NikolayKostov', password: '123456q' });

chatSystem.sendMessage({
    from: 'DonchoMinkov',
    to: 'NikolayKostov',
    text: 'Hey, Niki!'
});

chatSystem.sendMessage({
    from: 'NikolayKostov',
    to: 'DonchoMinkov',
    text: 'Hey, Doncho!'
});

chatSystem.sendMessage({
    from: 'NikolayKostov',
    to: 'DonchoMinkov',
    text: 'How are you today?'
});

chatSystem.sendMessage({
    from: 'DonchoMinkov',
    to: 'NikolayKostov',
    text: 'I\'m fine! You?'
});

chatSystem.sendMessage({
    from: 'NikolayKostov',
    to: 'DonchoMinkov',
    text: 'Same here.'
});

// Wait unit all messages where saved
setTimeout(function () {
    chatSystem.getMessages({
        with: 'DonchoMinkov',
        and: 'NikolayKostov'
    });
}, 1000);