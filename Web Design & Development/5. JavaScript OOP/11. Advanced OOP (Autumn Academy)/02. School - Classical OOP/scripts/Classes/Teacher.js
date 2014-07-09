define(function(require) {

    // Include utility functions and parent class
    var utility = require('../Helper/utility.js');
    var Human = require('./Human.js')

    // Constructor
    function Teacher(firstName, lastName, age, specialty) {
        Human.apply(this, arguments);

        this.specialty = specialty;
    }

    // Inheritance of parent
    Teacher.inherit(Human);

    Teacher.prototype.introduce = function() {
        return Human.prototype.introduce.apply(this, arguments) + ", Specialty: " + this.specialty;
    }

    return Teacher;
})