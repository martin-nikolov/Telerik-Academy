define(function(require) {

    // Include utility functions and parent class
    var utility = require('../Helper/utility.js');
    var PropulsionUnit = require('./PropulsionUnit.js')

    // Enumeration
    var spinDirections = {
        CLOCKWISE: "CLOCKWISE", 
        COUNTERCLOCKWISE: "COUNTER-CLOCKWISE"
    }

    // Constructor
    function Propeller(finsCount) {
        PropulsionUnit.call(this, arguments);

        this.finsCount = finsCount;
        this.spinDirection = spinDirections.CLOCKWISE;
    }

    // Inheritance of parent
    Propeller.inherit(PropulsionUnit);

    // Produce acceleration (change in speed) Property
    Propeller.prototype.produceAcceleration = function() {
        return (this.spinDirection === spinDirections.CLOCKWISE ? 1 : -1) * this.finsCount;
    }

    // Change spin direction Property
    Propeller.prototype.changeSpinDirection = function() {
        var isClockwise = this.spinDirection === spinDirections.CLOCKWISE;

        this.spinDirection = 
             spinDirections[isClockwise ? 'COUNTERCLOCKWISE' : 'CLOCKWISE'];
    }

    return Propeller;
})