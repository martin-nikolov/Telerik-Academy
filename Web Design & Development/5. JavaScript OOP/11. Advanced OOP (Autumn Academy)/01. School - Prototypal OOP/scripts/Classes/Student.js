define(function(require) {

    // Include utility functions and parent class
    var utility = require('../Helper/utility.js');
    var Human = require('./Human.js')

    var Student = Human.extend({
        init: function(firstName, lastName, age, grade) {
            Human.init.apply(this, arguments);
            
            this.grade = grade;

            return this;
        },
        introduce: function() {
            return Human.introduce.apply(this) + ", Grade: " + this.grade;
        }
    });

    return Student;
})