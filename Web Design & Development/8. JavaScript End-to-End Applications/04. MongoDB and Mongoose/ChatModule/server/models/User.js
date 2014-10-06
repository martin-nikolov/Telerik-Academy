var mongoose = require('mongoose');

var userSchema = mongoose.Schema({
    username: { type: String, required: true, unique: true },
    password: { type: String }
});

mongoose.model('User', userSchema);
