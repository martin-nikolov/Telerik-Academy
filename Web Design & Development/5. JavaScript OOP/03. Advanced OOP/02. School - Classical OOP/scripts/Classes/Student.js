define(function(require) {

    // Include utility functions and parent class
    var utility = require('../Helper/utility.js');
    var Human = require('./Human.js')

    // Constructor
    function Student(firstName, lastName, age, grade) {
        Human.apply(this, arguments);

        this.grade = grade;
    }

    // Inheritance of parent
    Student.inherit(Human);

    Student.prototype.introduce = function() {
        return Human.prototype.introduce.apply(this, arguments) + ", Grade: " + this.grade;
    }

    return Student;
})