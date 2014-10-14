var mongoose = require('mongoose');

module.exports.init = function() {
    var fileSchema = mongoose.Schema({
        url: { type: String, required: true, unique: true },
        uploadingDate: { type: Date, default: new Date() },
        fileName: String,
        isPrivate: { type: Boolean, default: false }
    });

    var File = mongoose.model('File', fileSchema);
};