var mongoose = require('mongoose');

module.exports.init = function () {
    var eventSchema = mongoose.Schema({
        title: { type: String, required: '{PATH} is required' },
        description: { type: String, required: '{PATH} is required' },
        eventDate: { type: Date, required: '{PATH} is required', default: Date.now },
        type: { type: String, enum: [ 'public', 'initiative-based', 'initiative-and-season-based' ] },
        location: {
            latitude: { type: Number },
            longitude: { type: Number }
        },
        eventPoints: {
            organization: { type: Number, min: 0, max: 5, default: 0 },
            venue: { type: Number, min: 0, max: 5, default: 0 },
            numberOfVoters: { type: Number, min: 0, default: 0 }
        },
        initiative: {
            name: { type: String, required: '{PATH} is required' },
            season: { type: String }
        },
        creatorName: { type: String, required: '{PATH} is required' },
        phoneNumber: { type: String, required: '{PATH} is required' },
        category: { type: String, enum: [ 'Academy initiative', 'Free time' ] },
        comments: [
            {
                creatorName: { type: String, required: '{PATH} is required' },
                content: { type: String, required: '{PATH} is required' }
            }
        ],
        joinedInUsers: [
            {
                userId: { type: mongoose.Schema.Types.ObjectId, required: '{PATH} is required' },
                username: { type: String, required: '{PATH} is required' }
            }
        ]
    });

    var Event = mongoose.model('Event', eventSchema);
};