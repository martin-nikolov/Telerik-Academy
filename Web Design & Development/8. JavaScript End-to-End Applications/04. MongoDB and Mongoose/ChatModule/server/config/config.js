var path = require('path'),
    rootPath = path.normalize(__dirname + '/../..');

module.exports = {
    development: {
        rootPath: rootPath,
        db: 'mongodb://localhost/crowdchat',
        port: process.env.PORT || 3030
    }
};