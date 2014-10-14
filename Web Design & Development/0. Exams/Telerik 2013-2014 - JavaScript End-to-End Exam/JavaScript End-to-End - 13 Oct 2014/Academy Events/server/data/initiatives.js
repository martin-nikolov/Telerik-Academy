var Initiative = require('mongoose').model('Initiative');

module.exports = {
    getAll: function (callback) {
        Initiative.find({}, function (error, data) {
            callback(data);
        });
    },
    getById: function (id, callback) {
        Initiative.findOne({ _id: id }, function (error, data) {
            callback(data);
        });
    },
    getByIds: function (ids, callback) {
        Initiative.find({_id: {$in: ids}}, function (error, data) {
            callback(data);
        });
    },
    create: function (initiative, callback) {
        Initiative.create(initiative, callback);
    }
};