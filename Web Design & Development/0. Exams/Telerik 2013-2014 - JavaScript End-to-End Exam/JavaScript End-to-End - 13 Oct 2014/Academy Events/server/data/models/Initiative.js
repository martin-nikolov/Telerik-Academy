var mongoose = require('mongoose');

module.exports.init = function () {
    var initiativeSchema = mongoose.Schema({
        name: { type: String, required: '{PATH} is required' },
        season: { type: String, required: '{PATH} is required' }
    });

    var Initiative = mongoose.model('Initiative', initiativeSchema);

    Initiative.find({}, function (error, data) {
        if (data.length) {
            return;
        }

        Initiative.create({ name: 'Software Academy ', season: '2013' });
        Initiative.create({ name: 'Software Academy ', season: '2014' });
        Initiative.create({ name: 'School Academy ', season: '2014' });
        Initiative.create({ name: 'Kids Academy ', season: '2014' });
        Initiative.create({ name: 'Algo Academy ', season: '2015' });
    })
};