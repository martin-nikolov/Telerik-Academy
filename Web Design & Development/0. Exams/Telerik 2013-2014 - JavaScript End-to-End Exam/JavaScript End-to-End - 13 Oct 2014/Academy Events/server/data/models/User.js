var mongoose = require('mongoose'),
    encryption = require('../../utilities/encryption'),
    InitiativeSchema = require('../models/Initiative').schema;

var defaultImgUrl = 'http://telerikacademy.com/Content/Images/DefaultAvatar/default_180x180.jpg';

module.exports.init = function () {
    var userSchema = mongoose.Schema({
        username: { type: String, required: '{PATH} is required', unique: true },
        firstName: { type: String, required: '{PATH} is required' },
        lastName: { type: String, required: '{PATH} is required' },
        email: { type: String, required: '{PATH} is required' },
        profileImgUrl: { type: String, default: defaultImgUrl },
        phoneNumber: { type: String },
        initiatives: [InitiativeSchema],
        eventPoints: { type: Number, min: 0 },
        externalProfiles: {
            facebook: { type: String },
            twitter: { type: String },
            googlePlus: { type: String },
            linkedIn: { type: String }
        },
        salt: String,
        hashPass: String,
        points: Number
    });

    // Validation
    userSchema.path('username').validate(function (value) {
        return value.length >= 6 && value.length <= 20;
    });

    userSchema.method({
        authenticate: function (password) {
            return encryption.generateHashedPassword(this.salt, password) === this.hashPass;
        }
    });

    var User = mongoose.model('User', userSchema);
};


