define(function(require) {

    // Include utility functions and parent class
    var utility = require('../Helper/utility.js');
    var PropulsionUnit = require('./PropulsionUnit.js')

    // Constructor
    function Wheel(radius) {
        PropulsionUnit.apply(this, arguments);

        this.radius = radius;
    }

    // Inheritance of parent
    Wheel.inherit(PropulsionUnit);

    // Produce acceleration (change in speed) Property
    Wheel.prototype.produceAcceleration = function() {
        return utility.circle.calculatePerimeter(this.radius);
    }
    
    return Wheel;
})