define(function(require) {

    // Include utility functions and parent class
    var utility = require('../Helper/utility.js');
    var Vehicle = require('./Vehicle.js')

    // Constructor
    function WaterVehicle() {
        var args = Array.prototype.slice.call(arguments);

        Vehicle.call(this, args);
    }

    // Inheritance of parent
    WaterVehicle.inherit(Vehicle);

    // Property for changing spin direction
    WaterVehicle.prototype.changeSpinDirection = function() {
        this.propulsionUnits.forEach(function(propeller) {
            propeller.changeSpinDirection();
        });
    }

    return WaterVehicle;
})