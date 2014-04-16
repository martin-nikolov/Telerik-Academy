define(function(require) {

    // Include parent class
    var utility = require('../Helper/utility.js')
    var Human = require('./Human.js')

    var Teacher = Human.extend({
        init: function(firstName, lastName, age, specialty) {
            Human.init.apply(this, arguments);
            
            this.specialty = specialty;
            
            return this;
        },
        introduce: function() {
            return Human.introduce.apply(this) + ", Specialty: " + this.specialty;
        }
    });

    return Teacher;
})